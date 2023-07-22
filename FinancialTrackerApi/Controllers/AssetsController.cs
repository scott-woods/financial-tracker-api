using AutoMapper;
using FinancialTrackerApi.Context;
using FinancialTrackerApi.Models.DatabaseModels;
using FinancialTrackerApi.Models.DTOs;
using FinancialTrackerApi.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrackerApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/{userId}")]
    public class AssetsController : ControllerBase
    {
        private readonly ILogger<AssetsController> _log;
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;
        private IAssetService _assetService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dbContext"></param>
        public AssetsController(ILogger<AssetsController> log, AppDbContext dbContext, IMapper mapper, IAssetService assetService)
        {
            _log = log;
            _dbContext = dbContext;
            _mapper = mapper;
            _assetService = assetService;
        }

        #region GET

        /// <summary>
        /// Get all assets by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(List<AssetDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [HttpGet]
        public IActionResult GetAssets([FromRoute] int userId) 
        {
            try
            {
                //validate userId
                if (userId <= 0)
                {
                    var errorMessage = "Exception occurred while getting Assets - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                //get assets
                var assetDtos = _assetService.GetAllAssets(userId);

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
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [HttpGet("liquidAssets")]
        public IActionResult GetLiquidAssets([FromRoute] int userId)
        {
            try
            {
                //validate userId
                if (userId <= 0)
                {
                    var errorMessage = "Exception occurred while getting Liquid Assets - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var assetDtos = _assetService.GetLiquidAssets(userId);

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
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [HttpGet("nonLiquidAssets")]
        public IActionResult GetNonLiquidAssets([FromRoute] int userId)
        {
            try
            {
                //validate userId
                if (userId <= 0)
                {
                    var errorMessage = "Exception occurred while getting Non Liquid Assets - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var assetDtos = _assetService.GetNonLiquidAssets(userId);

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
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [HttpPost]
        public IActionResult AddAssets([FromRoute] int userId, List<AssetDTO> assetDtos)
        {
            try
            {
                //validate userId
                if (userId <= 0)
                {
                    var errorMessage = "Exception occurred while adding Assets - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var success = _assetService.UpdateAssetList(userId, assetDtos);

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
