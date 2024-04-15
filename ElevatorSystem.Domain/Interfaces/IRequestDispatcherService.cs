using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Events;

namespace ElevatorSystem.Domain.Interfaces
{
    public interface IRequestDispatcherService
    {
        Guid Id { get; }
        Task AddRequest(ElevatorRequest request);
        //List<ElevatorRequest> GetNextRequests(IElevatorContolService elevatorContolService);
        void Dispatch(IElevatorControlService elevator);

        void RemoveRequest(List<ElevatorRequest> request);

        #region listener
        // void RegisterElevator(IElevatorControlService elevatorControl);
        // void SubscribeToElevatorMovedEvent(IElevatorControlService elevator, EventHandler<ElevatorMovedEvent> handler);

        #endregion

    }
}