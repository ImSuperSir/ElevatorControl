using System.Collections;
using ElevatorSystem.Domain.Enums;

namespace ElevatorSystem.Domain.Entities
{
    public class ElevatorRequest
    {
        public int FromFloor { get; set; }

        public int ToFloor { get; init; }
        public ElevatorDirection Direction { get; set; }

        public ElevatorDirection GetFloorDirection(int pCurrentFloor)
        {
            if (pCurrentFloor == ToFloor)
                return ElevatorDirection.None;

            return ToFloor > pCurrentFloor ? ElevatorDirection.Up : ElevatorDirection.Down;
        }
        public RequestFrom RequestSource { get; init; }

        /// <summary>
        /// Inside Request
        /// </summary>
        /// <param name="floor">The inside buttonNumber</param>
        public ElevatorRequest(int floor)
        {
            ToFloor = floor;
            RequestSource = RequestFrom.Inside;
        }

        /// <summary>
        /// Outside Request
        /// </summary>
        /// <param name="fromFloor"></param>
        /// <param name="direction"></param>
        public ElevatorRequest(int fromFloor, ElevatorDirection direction)
        {
            FromFloor = fromFloor; // this is the floor wher the elevator is called from
            ToFloor = fromFloor;   // So, the elevator need to go there
            Direction = direction;
            RequestSource = RequestFrom.Outside;
        }

        public int NextFloor(int pCurrentFloor)
        {
            int x = pCurrentFloor;

            switch (Direction, ToFloor, pCurrentFloor)
            {
                case (ElevatorDirection.None, int toFloor, int currentFloor) when toFloor == currentFloor && Direction == ElevatorDirection.None:
                    x = currentFloor; // stay at the same floor
                    break;
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

        public override string ToString()
        {
            return $"Request From: {RequestSource.ToString()}, FromFloor:{FromFloor} tofloor:{ToFloor} Direction: {Direction.ToString()}";
        }
    }
}