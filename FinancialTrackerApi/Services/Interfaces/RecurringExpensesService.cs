using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;

namespace FinancialTrackerApi.Services.Interfaces
{
    public class RecurringExpensesService : IRecurringExpensesService
    {
        private readonly ILogger<RecurringExpensesService> _log;
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public RecurringExpensesService(ILogger<RecurringExpensesService> log, AppDbContext context, IMapper mapper)
        {
            _log = log;
            _context = context;
            _mapper = mapper;
        }

        public List<RecurringExpenseDTO> GetRecurringExpenses(int userId)
        {
            try
            {
                var recurringExpenseDtos = new List<RecurringExpenseDTO>();

                var recurringExpenses = _context.RecurringExpenses
                    .Where(e => e.User.Id == userId)
                    .ToList();

                if (recurringExpenses.Any())
                {
                    recurringExpenseDtos = recurringExpenses.Select(_mapper.Map<RecurringExpense, RecurringExpenseDTO>).ToList();
                }

                return recurringExpenseDtos;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting Recurring Expenses");
                throw;
            }
        }

        public bool AddRecurringExpense(int userId, RecurringExpenseDTO recurringExpenseDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var recurringExpense = _mapper.Map<RecurringExpenseDTO, RecurringExpense>(recurringExpenseDTO, opts =>
                {
                    opts.AfterMap((src, dest) =>
                    {
                        dest.User = user;
                    });
                });

                _context.RecurringExpenses.Add(recurringExpense);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while adding Recurring Expense");
                throw;
            }
        }
    }
}
