using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Application;
using ElevatorSystem.Application.DTOs;
using ElevatorSystem.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElevatorSystem.API.Controllers
{
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    {
        private readonly ILogger<ElevatorController> _logger;
        private readonly IElevatorService _elevatorService;

        public ElevatorController(ILogger<ElevatorController> logger
                        , IElevatorService elevatorService)
        {
            _logger = logger;
            _elevatorService = elevatorService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ElevatorRequestDto elevatorRequestDto)
        {
            try
            {
                await _elevatorService.ProcessRequestElevator(elevatorRequestDto.ToElevatorRequest());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing request");
                return StatusCode(500, "Error processing request");
            }
        }

    }
}