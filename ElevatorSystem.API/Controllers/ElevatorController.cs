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


        [HttpPost("InsidRequest")]
        public async Task<IActionResult> Post([FromBody] ElevatorInsideRequestDto elevatorRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _RequestDispatcherService.AddRequest(elevatorRequestDto.ToElevatorRequest());
            return Ok();

        }


        [HttpPost("OutSideRequest")]
        public async Task<IActionResult> Post([FromBody] ElevatorOutsideRequestDto elevatorOutsideRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _RequestDispatcherService.AddRequest(elevatorOutsideRequestDto.ToElevatorRequest());
            return Ok();

        }

    }
}