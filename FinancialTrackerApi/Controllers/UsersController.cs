using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _log;
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ILogger<UsersController> log)
        {
            _userService = userService;
            _log = log;
        }

        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _userService.GetUsers();

                return Ok(users);
            }
            catch (Exception e)
            {
                _log.LogError(e, "Exception occurred while getting users.");
                return StatusCode(500, e);
            }
        }
    }
}
