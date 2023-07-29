using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Models.RequestModels;
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
    public class ExpensesController : BaseApiController
    {
        private readonly ILogger<ExpensesController> _log;
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;
        private IExpenseService _expenseService;
        private IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dbContext"></param>
        public ExpensesController(ILogger<ExpensesController> log, AppDbContext dbContext, IMapper mapper,
            IExpenseService expenseService, IUserService userService) : base(log, userService)
        {
            _log = log;
            _dbContext = dbContext;
            _mapper = mapper;
            _expenseService = expenseService;
            _userService = userService;
        }

        #region GET

        [ProducesResponseType(typeof(List<ExpenseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet]
        public IActionResult GetExpenses(DateTime startDate, DateTime endDate)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting Expenses - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                //get expenses
                var expenseDtos = _expenseService.GetExpenses(userId.Value, startDate, endDate);

                return Ok(expenseDtos);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Expenses";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        [ProducesResponseType(typeof(float), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet("total")]
        public IActionResult GetTotalExpenses()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting total expenses - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var totalExpenses = _expenseService.GetTotalExpenses(userId.Value);

                return Ok(totalExpenses);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Total Expenses";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion

        #region POST

        /// <summary>
        /// add a single expense
        /// </summary>
        /// <param name="expense"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpPost]
        public IActionResult AddExpense(ExpenseDTO expense)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while adding Expense - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var success = _expenseService.AddExpense(userId.Value, expense);

                if (!success)
                {
                    var errorMessage = "Adding to Expenses failed";
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
                var errorMessage = "Exception occurred while adding Expense";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
