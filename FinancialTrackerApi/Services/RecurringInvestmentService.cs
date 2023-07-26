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

        public bool AddRecurringInvestment(int userId, RecurringInvestmentDTO recurringInvestmentDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
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

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while adding Recurring Investment");
                throw;
            }
        }
    }
}
