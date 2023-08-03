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

        public float GetTotalRecurringIncome(int userId)
        {
            try
            {
                var totalRecurringIncome = 0f;

                var recurringIncomes = _context.RecurringIncomes
                    .Where(e => e.User.Id == userId)
                    .ToList();

                foreach (var recurringIncome in recurringIncomes)
                {
                    totalRecurringIncome += recurringIncome.Amount;
                }

                return totalRecurringIncome;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting Total Recurring Income");
                throw;
            }
        }

        public RecurringIncomeDTO AddRecurringIncome(int userId, RecurringIncomeDTO recurringIncomeDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    throw new KeyNotFoundException();
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

                return _mapper.Map<RecurringIncome, RecurringIncomeDTO>(recurringIncome);
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurrred while adding Recurring Income");
                throw;
            }
        }

        public bool UpdateRecurringIncome(int userId, RecurringIncomeDTO recurringIncome)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var currentRecurringIncome = _context.RecurringIncomes.Find(recurringIncome.Id);

                if (currentRecurringIncome == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Recurring Income with id {recurringIncome.Id} not found");
                    return false;
                }

                _context.Entry(currentRecurringIncome).CurrentValues.SetValues(recurringIncome);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while updating Recurring Income");
                throw;
            }
        }

        public bool RemoveRecurringIncome(int userId, int recurringIncomeId)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var recurringIncome = _context.RecurringIncomes.Find(recurringIncomeId);

                if (recurringIncome == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Recurring Income with id {recurringIncomeId} not found");
                    return false;
                }

                _context.RecurringIncomes.Remove(recurringIncome);
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while deleting Recurring Income");
                throw;
            }
        }
    }
}
