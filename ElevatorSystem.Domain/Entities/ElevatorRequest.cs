using System.Collections;
using ElevatorSystem.Domain.Enums;

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


        //Generate the tests using xunit.net framework
        public int NextFloor(int pCurrentFloor)
        {
            int x = 0;

            switch (Direction, ToFloor, pCurrentFloor)
            {
                case (ElevatorDirection.Up, int toFloor, int currentFloor) when toFloor > currentFloor:
                    x = currentFloor + 1;
                    break;
                case (ElevatorDirection.Up, int toFloor, int currentFloor) when toFloor <= currentFloor:
                    x = toFloor;
                    break;
                case (ElevatorDirection.Down, int toFloor, int currentFloor) when toFloor < currentFloor:
                    x = currentFloor - 1;
                    break;
                case (ElevatorDirection.Down, int toFloor, int currentFloor) when toFloor >= currentFloor:
                    x = toFloor;
                    break;
            }
            return x;
        }
    }
}