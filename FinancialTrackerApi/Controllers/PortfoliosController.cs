using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FinancialTrackerApi.Controllers
{
    /// <summary>
    /// Controller for asset and debt data
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/{userId}")]
    public class PortfoliosController : ControllerBase
    {
        #region SETUP

        private readonly ILogger<PortfoliosController> _log;
        private readonly AppDbContext _dbContext;

        public PortfoliosController(AppDbContext dbContext, ILogger<PortfoliosController> log)
        {
            _dbContext = dbContext;
            _log = log;
        }

        #endregion

        #region GET

        /// <summary>
        /// Get all assets
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ApiVersion("1.0")]
        [ProducesResponseType(typeof(List<Asset>), StatusCodes.Status200OK)]
        [HttpGet]
        public IActionResult GetAssets([FromRoute] int userId)
        {
            throw new NotImplementedException();
        }

        [ApiVersion("1.0")]
        [HttpGet("debts")]
        public IActionResult GetDebts([FromRoute] int userId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region POST

        #endregion
    }
}
