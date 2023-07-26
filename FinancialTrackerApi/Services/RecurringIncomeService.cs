using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;

namespace FinancialTrackerApi.Services
{
    public class RecurringIncomeService : IRecurringIncomeService
    {
        private readonly ILogger<RecurringIncomeService> _log;
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public RecurringIncomeService(ILogger<RecurringIncomeService> log, AppDbContext context, IMapper mapper)
        {
            _log = log;
            _context = context;
            _mapper = mapper;
        }

        public List<RecurringIncomeDTO> GetRecurringIncome(int userId)
        {
            try
            {
                var recurringIncomeDtos = new List<RecurringIncomeDTO>();

                var recurringIncomes = _context.RecurringIncomes
                    .Where(e => e.User.Id == userId)
                    .ToList();

                if (recurringIncomes.Any())
                {
                    recurringIncomeDtos = recurringIncomes.Select(_mapper.Map<RecurringIncome, RecurringIncomeDTO>).ToList();
                }

                return recurringIncomeDtos;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting Recurring Income");
                throw;
            }
        }

        public bool AddRecurringIncome(int userId, RecurringIncomeDTO recurringIncomeDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var recurringIncome = _mapper.Map<RecurringIncomeDTO, RecurringIncome>(recurringIncomeDTO, opts =>
                {
                    opts.AfterMap((src, dest) =>
                    {
                        dest.User = user;
                    });
                });

                _context.RecurringIncomes.Add(recurringIncome);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurrred while adding Recurring Income");
                throw;
            }
        }
    }
}
