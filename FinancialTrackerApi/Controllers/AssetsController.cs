using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
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
    public class AssetsController : BaseApiController
    {
        private readonly ILogger<AssetsController> _log;
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;
        private IAssetService _assetService;
        private IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dbContext"></param>
        public AssetsController(ILogger<AssetsController> log, AppDbContext dbContext, IMapper mapper,
            IAssetService assetService, IUserService userService) : base(log, userService)
        {
            _log = log;
            _dbContext = dbContext;
            _mapper = mapper;
            _assetService = assetService;
            _userService = userService;
        }

        #region GET

        /// <summary>
        /// Get all assets
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<AssetDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet]
        public IActionResult GetAssets() 
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting Assets - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                //get assets
                var assetDtos = _assetService.GetAllAssets(userId.Value);

                return Ok(assetDtos);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Assets";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        [ProducesResponseType(typeof(List<AssetDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet("liquidAssets")]
        public IActionResult GetLiquidAssets()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting Liquid Assets - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var assetDtos = _assetService.GetLiquidAssets(userId.Value);

                return Ok(assetDtos);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Liquid Assets";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        [ProducesResponseType(typeof(List<AssetDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet("nonLiquidAssets")]
        public IActionResult GetNonLiquidAssets()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting Non Liquid Assets - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var assetDtos = _assetService.GetNonLiquidAssets(userId.Value);

                return Ok(assetDtos);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Non Liquid Assets";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion

        #region POST

        [ApiVersion("1.0")]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest | StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [Authorize]
        [HttpPost]
        public IActionResult AddAssets(List<AssetDTO> assetDtos)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while adding Assets - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var success = _assetService.UpdateAssetList(userId.Value, assetDtos);

                if (!success)
                {
                    var errorMessage = "Exception occurred while adding Assets";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return StatusCode(500, e);
                }
                else
                {
                    return Ok(success);
                }
            }
            catch(Exception e)
            {
                var errorMessage = "Exception occurred while adding Assets";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
