﻿using AutoMapper;
using FinancialTrackerApi.Context;
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
    public class RecurringInvestmentsController : BaseApiController
    {
        private readonly ILogger<RecurringInvestmentsController> _log;
        private readonly AppDbContext _dbContext;
        private IMapper _mapper;
        private IRecurringInvestmentService _recurringInvestmentService;
        private IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="log"></param>
        /// <param name="dbContext"></param>
        public RecurringInvestmentsController(ILogger<RecurringInvestmentsController> log, AppDbContext dbContext, IMapper mapper,
            IRecurringInvestmentService recurringInvestmentService, IUserService userService) : base(log, userService)
        {
            _log = log;
            _dbContext = dbContext;
            _mapper = mapper;
            _recurringInvestmentService = recurringInvestmentService;
            _userService = userService;
        }

        #region GET

        [ProducesResponseType(typeof(List<RecurringInvestmentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpGet]
        public IActionResult GetRecurringInvestments()
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while getting Recurring Investments - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                //get recurring investments
                var recurringInvestmentDtos = _recurringInvestmentService.GetRecurringInvestments(userId.Value);

                return Ok(recurringInvestmentDtos);
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while getting Recurring Investments";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion

        #region POST

        [ProducesResponseType(typeof(RecurringInvestmentDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpPost]
        public IActionResult AddRecurringInvestment(RecurringInvestmentDTO recurringInvestmentDTO)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while adding Recurring Investment - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var newRecurringInvestment = _recurringInvestmentService.AddRecurringInvestment(userId.Value, recurringInvestmentDTO);

                if (newRecurringInvestment == null)
                {
                    var errorMessage = "Adding to Recurring Investments failed";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return StatusCode(500, e);
                }
                else
                {
                    return Ok(newRecurringInvestment);
                }
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while adding Recurring Investment";
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
        public IActionResult UpdateRecurringInvestment(RecurringInvestmentDTO updatedRecurringInvestment)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while updating recurring investment - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var success = _recurringInvestmentService.UpdateRecurringInvestment(userId.Value, updatedRecurringInvestment);

                if (!success)
                {
                    var errorMessage = "Update to Recurring Investment failed";
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
                var errorMessage = "Exception occurred while updating Recurring Investment";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion

        #region DELETE

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status500InternalServerError)]
        [ApiVersion("1.0")]
        [Authorize]
        [HttpDelete]
        public IActionResult RemoveRecurringInvestment(int recurringInvestmentId)
        {
            try
            {
                //validate userId
                if (!userId.HasValue)
                {
                    var errorMessage = "Exception occurred while deleting recurring investment - Invalid User Id";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return BadRequest(e);
                }

                var success = _recurringInvestmentService.RemoveRecurringInvestment(userId.Value, recurringInvestmentId);

                if (!success)
                {
                    var errorMessage = "Deleting Recurring Investment failed";
                    var e = new Exception(errorMessage);
                    _log.LogError(errorMessage);
                    return StatusCode(500, e);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                var errorMessage = "Exception occurred while deleting Recurring Investment";
                _log.LogError(e, errorMessage);
                return StatusCode(500, e);
            }
        }

        #endregion
    }
}
