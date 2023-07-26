using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class RecurringExpensesController : BaseApiController
    {
        private readonly ILogger<RecurringExpensesController> _log;
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;
        private IRecurringExpensesService _recurringExpensesService;
        private IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dbContext"></param>
        public RecurringExpensesController(ILogger<RecurringExpensesController> log, AppDbContext dbContext, IMapper mapper,
            IRecurringExpensesService recurringExpensesService, IUserService userService) : base(log, userService)
        {
            _log = log;
            _dbContext = dbContext;
            _mapper = mapper;
            _recurringExpensesService = recurringExpensesService;
            _userService = userService;
        }

        #region GET

        [ProducesResponseType(typeof(List<RecurringExpenseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet]
        public IActionResult GetRecurringExpenses()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting Recurring Expenses - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                //get recurring expenses
                var recurringExpenses = _recurringExpensesService.GetRecurringExpenses(userId.Value);

                return Ok(recurringExpenses);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Recurring Expenses";
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
        public IActionResult AddRecurringExpense(RecurringExpenseDTO recurringExpenseDTO)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while adding Recurring Expense - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var success = _recurringExpensesService.AddRecurringExpense(userId.Value, recurringExpenseDTO);

                if (!success)
                {
                    var errorMessage = "Failed to add Recurring Expense";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return StatusCode(500, e);
                }

                return Ok(success);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while adding Recurring Expense";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
