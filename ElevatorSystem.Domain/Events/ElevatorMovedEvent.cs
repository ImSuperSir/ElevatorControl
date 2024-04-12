using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorSystem.Domain.Events
{
    public class ElevatorMovedEvent
    {
        public int NewFloor { get; }

        public ElevatorMovedEvent(int newFloor)
        {
            NewFloor = newFloor;
        }
    }
}