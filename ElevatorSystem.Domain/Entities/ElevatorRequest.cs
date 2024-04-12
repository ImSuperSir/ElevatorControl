using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Events;

namespace ElevatorSystem.Domain.Entities
{
    public class ElevatorRequest
    {
        public int Floor { get; set; }

        public ElevatorDirection Direction { get; set; }

        public ElevatorRequest(int floor, ElevatorDirection direction)
        {
            Floor = floor;
            Direction = direction;
        }
    }
}