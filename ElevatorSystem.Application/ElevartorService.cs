using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Events;

namespace ElevatorSystem.Application
{
    public class ElevatorService : IElevatorService
    {
        private readonly Elevator _elevator;

        public ElevatorService(Elevator elevator)
        {
            _elevator = elevator;
            // Subscribe to the ElevatorMoved event
            _elevator!.ElevatorMoved += Elevator_ElevatorMoved;
        }
        public async Task ProcessRequestElevator(ElevatorRequest request)
        {
            ElevatorRequestList.AddRequest(request);
            await Task.CompletedTask;
        }

  

        private void Elevator_ElevatorMoved(ElevatorMovedEvent elevatorMovedEvent)
        {
            // Handle the elevator movement event, e.g., log movement or notify other systems
            Console.WriteLine($"Elevator has moved to floor {elevatorMovedEvent.NewFloor}.");
        }


    }
}
