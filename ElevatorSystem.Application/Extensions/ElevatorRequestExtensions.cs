using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Application.DTOs;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Enums;

namespace ElevatorSystem.Application.Extensions
{
    public static class ElevatorRequestExtensions
    {
        public static ElevatorRequest ToElevatorRequest(this ElevatorInsideRequestDto elevatorRequestDto)
        {
            return new ElevatorRequest(elevatorRequestDto.Floor);
        }

        public static ElevatorRequest ToElevatorRequest(this ElevatorOutsideRequestDto elevatorRequestDto)
        {
            return new ElevatorRequest(elevatorRequestDto.FromFloor, (ElevatorDirection)(int)elevatorRequestDto.Direction );
        }

    }
}