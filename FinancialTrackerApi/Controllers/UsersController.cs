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
    public class UsersController : BaseApiController
    {
        private readonly ILogger<UsersController> _log;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ILogger<UsersController> log) : base(log, userService)
        {
            _userService = userService;
            _log = log;
        }

        #region GET

        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet]
        public IActionResult GetUserMetadata()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting User - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var user = _userService.GetUser(userId.Value);

                if (user == null)
                {
                    var errorMessage = "Exception occurred while getting User - User not found";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return NotFound(e);
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting User Metadata";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion

        #region PUT

        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpPut]
        public IActionResult UpdateSavingsGoal(float newSavingsGoal)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while updating Savings Goal - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var success = _userService.UpdateSavingsGoal(userId.Value, newSavingsGoal);

                if (!success)
                {
                    var errorMessage = "Updating Savings Goal failed";
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
                var errorMessage = "Exception occurred while updating Savings Goal";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
