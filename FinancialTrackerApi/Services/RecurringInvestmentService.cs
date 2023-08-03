using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;

namespace FinancialTrackerApi.Services
{
    public class RecurringInvestmentService : IRecurringInvestmentService
    {
        private readonly ILogger<RecurringInvestmentService> _log;
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public RecurringInvestmentService(ILogger<RecurringInvestmentService> log, AppDbContext context, IMapper mapper)
        {
            _log = log;
            _context = context;
            _mapper = mapper;
        }

        public List<RecurringInvestmentDTO> GetRecurringInvestments(int userId)
        {
            try
            {
                var recurringInvestmentDtos = new List<RecurringInvestmentDTO>();

                var recurringInvestments = _context.RecurringInvestments
                    .Where(e => e.User.Id == userId)
                    .ToList();

                if (recurringInvestments.Any())
                {
                    recurringInvestmentDtos = recurringInvestments.Select(_mapper.Map<RecurringInvestment, RecurringInvestmentDTO>).ToList();
                }

                return recurringInvestmentDtos;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting Recurring Investments");
                throw;
            }
        }

        public RecurringInvestmentDTO AddRecurringInvestment(int userId, RecurringInvestmentDTO recurringInvestmentDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    throw new KeyNotFoundException();
                }

                var recurringInvestment = _mapper.Map<RecurringInvestmentDTO, RecurringInvestment>(recurringInvestmentDTO, opts =>
                {
                    opts.AfterMap((src, dest) =>
                    {
                        dest.User = user;
                    });
                });

                _context.RecurringInvestments.Add(recurringInvestment);

                _context.SaveChanges();

                return _mapper.Map<RecurringInvestment, RecurringInvestmentDTO>(recurringInvestment);
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while adding Recurring Investment");
                throw;
            }
        }

        public bool UpdateRecurringInvestment(int userId, RecurringInvestmentDTO recurringInvestment)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var currentRecurringInvestment = _context.RecurringInvestments.Find(recurringInvestment.Id);

                if (currentRecurringInvestment == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Recurring Investment with id {recurringInvestment.Id} not found");
                    return false;
                }

                _context.Entry(currentRecurringInvestment).CurrentValues.SetValues(recurringInvestment);
                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while updating Recurring Investment");
                throw;
            }
        }

        public bool RemoveRecurringInvestment(int userId, int recurringInvestmentId)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var recurringInvestment = _context.RecurringInvestments.Find(recurringInvestmentId);

                if (recurringInvestment == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Recurring Investment with id {recurringInvestmentId} not found");
                    return false;
                }

                _context.RecurringInvestments.Remove(recurringInvestment);
                return _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while deleting Recurring Investment");
                throw;
            }
        }
    }
}
