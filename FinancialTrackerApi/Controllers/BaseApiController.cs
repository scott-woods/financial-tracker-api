using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinancialTrackerApi.Controllers
{
    public class BaseApiController : Controller
    {
        private readonly ILogger<BaseApiController> _log;
        private IUserService _userService;

        public string? auth0UserId;
        public int? userId;

        public BaseApiController(ILogger<BaseApiController> log, IUserService userService)
        {
            _log = log;
            _userService = userService;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            if (userIdClaim != null)
            {
                auth0UserId = userIdClaim.Value;

                var user = _userService.GetUserByAuth0Id(auth0UserId);
                if (user != null)
                {
                    userId = user.Id;
                }
            }
        }
    }
}
