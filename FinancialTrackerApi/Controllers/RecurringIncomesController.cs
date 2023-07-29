using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RecurringIncomesController : BaseApiController
    {
        private readonly ILogger<RecurringIncomesController> _log;
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;
        private IRecurringIncomeService _recurringIncomeService;
        private IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dbContext"></param>
        public RecurringIncomesController(ILogger<RecurringIncomesController> log, AppDbContext dbContext, IMapper mapper,
            IRecurringIncomeService recurringIncomeService, IUserService userService) : base(log, userService)
        {
            _log = log;
            _dbContext = dbContext;
            _mapper = mapper;
            _recurringIncomeService = recurringIncomeService;
            _userService = userService;
        }

        #region GET

        [ProducesResponseType(typeof(List<RecurringIncomeDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet]
        public IActionResult GetRecurringIncome()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting recurring income - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var recurringIncomeDtos = _recurringIncomeService.GetRecurringIncome(userId.Value);

                return Ok(recurringIncomeDtos);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Recurring Income";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// get the total value of recurring incomes for this user
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(float), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet("total")]
        public IActionResult GetTotalRecurringIncome()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting total recurring income - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var totalRecurringIncome = _recurringIncomeService.GetTotalRecurringIncome(userId.Value);

                return Ok(totalRecurringIncome);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Total Recurring Income";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion

        #region POST

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpPost]
        public IActionResult AddRecurringIncome(RecurringIncomeDTO recurringIncomeDTO)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while adding recurring income - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var success = _recurringIncomeService.AddRecurringIncome(userId.Value, recurringIncomeDTO);

                if (!success)
                {
                    var errorMessage = "Adding to Recurring Income failed";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return StatusCode(500, e);
                }
                else
                {
                    return Ok(success);
                }
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while adding Recurring Income";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
