using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;

namespace FinancialTrackerApi.Services
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

        public RecurringExpenseDTO AddRecurringExpense(int userId, RecurringExpenseDTO recurringExpenseDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    throw new KeyNotFoundException();
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

                return _mapper.Map<RecurringExpense, RecurringExpenseDTO>(recurringExpense);
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while adding Recurring Expense");
                throw;
            }
        }

        public bool UpdateRecurringExpense(int userId, RecurringExpenseDTO recurringExpense)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var currentRecurringExpense = _context.RecurringExpenses.Find(recurringExpense.Id);

                if (currentRecurringExpense == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Recurring Expense with id {recurringExpense.Id} not found");
                    return false;
                }

                _context.Entry(currentRecurringExpense).CurrentValues.SetValues(recurringExpense);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while updating Recurring Expense");
                throw;
            }
        }

        public bool RemoveRecurringExpense(int userId, int recurringExpenseId)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var recurringExpense = _context.RecurringExpenses.Find(recurringExpenseId);

                if (recurringExpense == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Recurring Expense with id {recurringExpenseId} not found");
                    return false;
                }

                _context.RecurringExpenses.Remove(recurringExpense);
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while deleting Recurring Expense");
                throw;
            }
        }
    }
}
