using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;

namespace FinancialTrackerApi.Services
{
    public class NetWorthReportService : INetWorthReportService
    {
        private readonly ILogger<NetWorthReportService> _log;
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public NetWorthReportService(ILogger<NetWorthReportService> log, AppDbContext context, IMapper mapper)
        {
            _log = log;
            _context = context;
            _mapper = mapper;
        }

        public List<NetWorthReportDTO> GetNetWorthReports(int userId)
        {
            try
            {
                var netWorthReportDtos = new List<NetWorthReportDTO>();

                var netWorthReports = _context.NetWorthReports
                    .Where(e => e.User.Id == userId)
                    .OrderByDescending(e => e.Date)
                    .ToList();

                if (netWorthReports.Any())
                {
                    netWorthReportDtos = netWorthReports.Select(_mapper.Map<NetWorthReport, NetWorthReportDTO>).ToList();
                }

                return netWorthReportDtos;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting Net Worth Reports");
                throw;
            }
        }

        public bool AddNetWorthReport(int userId, NetWorthReportDTO netWorthReportDTO)
        {
            try
            {
                var user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();

                if (user == null)
                {
                    if (_log.IsEnabled(LogLevel.Debug)) _log.LogDebug($"Failed to find User with id {userId}");
                    return false;
                }

                var netWorthReport = _mapper.Map<NetWorthReportDTO, NetWorthReport>(netWorthReportDTO, opts =>
                {
                    opts.AfterMap((src, dest) =>
                    {
                        dest.User = user;
                    });
                });

                _context.NetWorthReports.Add(netWorthReport);

                _context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while adding Net Worth Report");
                throw;
            }
        }
    }
}
