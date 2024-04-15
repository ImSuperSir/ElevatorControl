//using ElevatorSystem.Domain.Enums;

using ElevatorSystem.Domain.Enums;

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