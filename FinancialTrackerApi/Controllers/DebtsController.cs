using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/{userId}")]
    public class DebtsController : ControllerBase
    {
        private readonly ILogger<DebtsController> _log;
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;
        private IDebtService _debtService;
        private IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dbContext"></param>
        public DebtsController(ILogger<DebtsController> log, AppDbContext dbContext, IMapper mapper, IDebtService debtService,
            IUserService userService)
        {
            _log = log;
            _dbContext = dbContext;
            _mapper = mapper;
            _debtService = debtService;
            _userService = userService;
        }

        #region GET

        [ProducesResponseType(typeof(List<DebtDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [HttpGet]
        public IActionResult GetDebts([FromRoute] int userId)
        {
            try
            {
                //validate userId
                if (userId <= 0)
                {
                    var errorMessage = "Exception occurred while getting Debts - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                //get user, throws key not found exception if user isn't found
                var userDto = _userService.GetUser(userId);

                //Get debts
                var debts = _debtService.GetDebts(userId);

                return Ok(debts);
            }
            catch (KeyNotFoundException e)
            {
                var message = "Exception occurred while getting Debts";
                _log.LogError(e, message);
                return NotFound(e);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Debts";
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
        [HttpPost]
        public IActionResult AddDebts([FromRoute] int userId, List<DebtDTO> debtDtos)
        {
            try
            {
                //validate userId
                if (userId <= 0)
                {
                    var errorMessage = "Exception occurred while getting Debts - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                //get user, throws key not found exception if user isn't found
                var userDto = _userService.GetUser(userId);

                var success = _debtService.UpdateDebtList(userId, debtDtos);

                if (!success)
                {
                    var errorMessage = "Exception occurred while adding Debts";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return StatusCode(500, e);
                }
                else
                {
                    return Ok(success);
                }
            }
            catch (KeyNotFoundException e)
            {
                var message = "Exception occurred while adding Debts";
                _log.LogError(e, message);
                return NotFound(e);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while adding Debts";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
