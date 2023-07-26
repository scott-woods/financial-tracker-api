using FinancialTrackerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text.Json;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IConfiguration _config;

        public AuthenticateController(IConfiguration config)
        {
            _config = config;
        }

        [HttpPost]
        public IActionResult Authenticate(AuthenticateRequest authRequest)
        {
            var domain = _config["Auth0:Domain"];
            var audience = _config["Auth0:Audience"];

            var client = new RestClient($"https://{domain}/oauth/token");
            var request = new RestRequest("", Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=password&username={authRequest.Email}&password={authRequest.Password}&audience={audience}&client_id=N9FVyn6Zyab4Z4VHvqTGBcplHmg7OzUH", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
            {
                return NotFound();
            }
            else
            {
                var jsonDocument = JsonDocument.Parse(response.Content);

                return Ok(jsonDocument.RootElement.GetProperty("access_token").GetString());
            }
        }
    }
}
