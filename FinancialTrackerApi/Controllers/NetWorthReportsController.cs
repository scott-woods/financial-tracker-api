using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class NetWorthReportsController : BaseApiController
    {
        private readonly ILogger<NetWorthReportsController> _log;
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;
        private INetWorthReportService _netWorthReportService;
        private IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dbContext"></param>
        public NetWorthReportsController(ILogger<NetWorthReportsController> log, AppDbContext dbContext, IMapper mapper,
            INetWorthReportService netWorthReportService, IUserService userService) : base(log, userService)
        {
            _log = log;
            _dbContext = dbContext;
            _mapper = mapper;
            _netWorthReportService = netWorthReportService;
            _userService = userService;
        }

        #region GET

        [ProducesResponseType(typeof(List<NetWorthReportDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet]
        public IActionResult GetNetWorthReports()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting Net Worth Reports - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                //get expenses
                var netWorthReportDtos = _netWorthReportService.GetNetWorthReports(userId.Value);

                return Ok(netWorthReportDtos);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Net Worth Reports";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion

        #region POST

        [ProducesResponseType(typeof(NetWorthReportDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpPost]
        public IActionResult AddNetWorthReport(NetWorthReportDTO netWorthReportDTO)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while adding Net Worth Report - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var newReport = _netWorthReportService.AddNetWorthReport(userId.Value, netWorthReportDTO);

                if (newReport == null)
                {
                    var errorMessage = "Adding to Net Worth Reports failed";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return StatusCode(500, e);
                }
                else
                {
                    return Ok(newReport);
                }
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while adding Net Worth Report";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
