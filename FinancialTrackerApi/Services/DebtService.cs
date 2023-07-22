using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;

namespace FinancialTrackerApi.Services
{
    public class DebtService : IDebtService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DebtService> _log;
        private readonly IMapper _mapper;

        public DebtService(AppDbContext context, ILogger<DebtService> log, IMapper mapper)
        {
            _context = context;
            _log = log;
            _mapper = mapper;
        }

        public List<DebtDTO> GetDebts(int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    var message = $"User with Id {userId} was not found.";
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug(message);
                    throw new KeyNotFoundException(message);
                }

                var debts = _context.Debts.Where(d => d.User.Id == userId).ToList();

                return debts.Select(_mapper.Map<Debt, DebtDTO>).ToList();
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting Debts");
                throw;
            }
        }

        public bool UpdateDebtList(int userId, List<DebtDTO> debtDtos)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    var message = $"User with Id {userId} was not found.";
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug(message);
                    throw new KeyNotFoundException(message);
                }

                //map debts from request to ef objects
                var newDebts = _mapper.Map<List<DebtDTO>, List<Debt>>(debtDtos, opts =>
                {
                    opts.AfterMap((src, dest) =>
                    {
                        dest.ForEach(d => d.User = user);
                    });
                });

                //Get current debts
                var currentDebts = _context.Debts.Where(d => d.User.Id == userId).ToList();

                //loop through debts from request
                foreach (var debt in newDebts)
                {
                    var existingDebt = currentDebts.FirstOrDefault(d => d.Id == debt.Id);

                    //if debt doesn't exist yet, add it
                    if (existingDebt == null)
                    {
                        _context.Debts.Add(debt);
                    }
                    else //otherwise, update it
                    {
                        _context.Entry(existingDebt).CurrentValues.SetValues(debt);
                    }
                }

                //delete debts that currently exist but aren't in the new debt list
                var debtsToDelete = currentDebts.Where(cd => !newDebts.Where(nd => nd.Id == cd.Id).Any()).ToList();
                if (debtsToDelete.Any())
                {
                    _context.RemoveRange(debtsToDelete);
                }

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while updating Debt list");
                throw;
            }
        }
    }
}
