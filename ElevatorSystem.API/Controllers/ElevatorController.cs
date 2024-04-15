using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Application;
using ElevatorSystem.Application.DTOs;
using ElevatorSystem.Application.Extensions;
using ElevatorSystem.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ElevatorSystem.API.Controllers
{
    [Route("[controller]")]
    public class ElevatorController : ControllerBase
    {
        private readonly ILogger<ElevatorController> _logger;
        private readonly IRequestDispatcherService _RequestDispatcherService;

        public ElevatorController(ILogger<ElevatorController> logger
                        , IRequestDispatcherService pIRequestDispatcherService)
        {
            _logger = logger;
            _RequestDispatcherService = pIRequestDispatcherService;
        }


        [HttpPost("UniqueRequest")]
        public async Task<IActionResult> Post([FromBody] ElevatorRequestDto elevatorRequestDto)
        {
            try
            {
                await _RequestDispatcherService.AddRequest(elevatorRequestDto.ToElevatorRequest());
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing request");
                return StatusCode(500, "Error processing request");
            }
        }


        [HttpPost("MultipleRequests")]
        public async Task<IActionResult> Post([FromBody] List<ElevatorRequestDto> elevatorRequestListDto)
        {
            try
            {

                foreach (var request in elevatorRequestListDto)
                {
                    await _RequestDispatcherService.AddRequest(request.ToElevatorRequest());
                }

                //await _elevatorService.ProcessRequestElevator(elevatorRequestDtoList.ToElevatorRequest());
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