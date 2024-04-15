using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Application.DTOs;
using ElevatorSystem.Domain.Entities;

namespace ElevatorSystem.Application.Extensions
{
    public static class ElevatorRequestExtensions
    {
        public static ElevatorRequest ToElevatorRequest(this ElevatorInsideRequestDto elevatorRequestDto)
        {
            return new ElevatorRequest(elevatorRequestDto.Floor, elevatorRequestDto.Direction);
        }

    }
}