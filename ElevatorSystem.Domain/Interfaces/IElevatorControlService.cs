using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Enums;
using ElevatorSystem.Domain.Events;

namespace ElevatorSystem.Domain.Interfaces
{

    public delegate void ElevatorMovedEventHandler(Object sender, ElevatorMovedEvent pElevatorMovedEvent);

    public interface IElevatorControlService
    {

        #region Properties

        Guid Id { get; init; }
        int CurrentFloor { get; }
        ElevatorDirection Direction { get; }
        #endregion

        #region Events   //We do not need this
        event ElevatorMovedEventHandler OnElevatorMovedEvent;
        #endregion


        #region Methods
        void AddRequests(List<ElevatorRequest> requestList);
        void MoveOneStep(int floor);
        void OpenDoor();
        void RemoveRequestDone(ElevatorRequest request);

        #endregion



    }
}