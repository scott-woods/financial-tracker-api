using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Services.Interfaces;
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

        public UsersController(IUserService userService, ILogger<UsersController> log)
        {
            _userService = userService;
            _log = log;
        }
    }
}
