using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Events;

namespace ElevatorSystem.Domain.Entities
{
    public class ElevatorRequest
    {
        public int FromFloor { get; set; }

        public int ToFloor { get; set; }
        public ElevatorDirection Direction { get; set; }

        public ElevatorRequest(int floor, ElevatorDirection direction)
        {
            ToFloor = floor;
            Direction = direction;
        }

        public int NextFloor(int currentFloor)
        {   int x = 0;
            if (Direction == ElevatorDirection.Up)
            {
                x = ToFloor > currentFloor ?  currentFloor + 1 : ToFloor;
            }
            else
            {
                x = ToFloor <= currentFloor ? ToFloor : currentFloor - 1;
            }
            return x;
        }
    }
}