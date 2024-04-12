using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorSystem.Domain.Events
{
    public class ElevatorRequestedEvent 
    {
        public int RequestedFloor { get; }
        public ElevatorDirection Direction { get; }

        public ElevatorRequestedEvent(int requestedFloor, ElevatorDirection direction)
        {
            RequestedFloor = requestedFloor;
            Direction = direction;
        }
    }
}