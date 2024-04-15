using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ElevatorSystem.Application;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Events;
using ElevatorSystem.Domain.Interfaces;
using Microsoft.Extensions.Hosting;

namespace ElevatorSystem.Infrastructure
{
    public class RequestDispatcherService : BackgroundService
                            , IRequestDispatcherService
                            , IDispatcherClientConnect
    {

        #region Properties

        public Guid Id { get; init; } 
        private readonly List<IElevatorControlService> _ElevatorControllers;
        private readonly ElevatorRequestList _RequestList;

        #endregion

        public RequestDispatcherService()
        {
            Id = Guid.NewGuid();
            _RequestList = new ElevatorRequestList();
            _ElevatorControllers = new List<IElevatorControlService>();
            Console.WriteLine($"RequestDispatcherService: {Id}, created {System.DateTime.UtcNow.ToString()}");
        }

        #region BackgroundService
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            //await Task.Delay(30000);
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine($"Dispatcher:{Id.ToString().Substring(30)} count: {_RequestList.Count} ");
                foreach (var elevator in _ElevatorControllers)
                {
                    Dispatch(elevator);
                }
                await Task.Delay(10000, stoppingToken);
            }
        }

        #endregion

        #region IRequestDispatcherService

        public async Task AddRequest(ElevatorRequest request)
        {
            _RequestList.AddRequest(request);
            await Task.CompletedTask;
        }
        public void Dispatch(IElevatorControlService elevator)
        {
            var lElevatorRequest = _RequestList.GetAllNextRequest(elevator.Direction, elevator.CurrentFloor);

            if (lElevatorRequest.Count > 0)
            {
                elevator.AddRequests(lElevatorRequest);
                RemoveRequest(lElevatorRequest); //Remove the request from the list
                Console.WriteLine($"Request sent to Elevator:{elevator.Id.ToString().Substring(30)}, {_RequestList.Count} requests remaining");
            }
        }
        public void RemoveRequest(List<ElevatorRequest> requestsToRemove)
        {
            _RequestList.RemoveRequests(requestsToRemove);
        }


        #endregion

        #region IDispatcherClientConnect
        public void Connect(IElevatorControlService elevatorControlService)
        {
            Console.WriteLine($"Dispatcher:{Id.ToString().Substring(30)} connected to Elevator:{elevatorControlService.Id.ToString().Substring(30)}");
            _ElevatorControllers.Add(elevatorControlService);
        }


        #endregion


        // public List<ElevatorRequest> GetNextRequests(IElevatorContolService elevatorContolService)
        // {
        //     //return _elevatorRequestList.GetNextRequest(elevatorContolService.Direction, elevatorContolService.CurrentFloor);
        // }



        #region listener funcionality

        // public void RegisterElevator(IElevatorControlService elevatorControl)
        // {
        //     _ElevatorControllers.Add(elevatorControl);
        //     elevatorControl.OnElevatorMovedEvent += OneElevatorHasMoveEvent;
        // }

        // private void OneElevatorHasMoveEvent(object sender, ElevatorMovedEvent pElevatorMovedEvent)
        // {
        //     // IElevatorContolService lIElevatorContolService = (IElevatorContolService)sender.GetType();

        //     // //ar lElevatorRequest = _elevatorRequestList.GetNextRequest(lIElevatorContolService.Direction, lIElevatorContolService.CurrentFloor);

        //     // if (GetNextRequests(lIElevatorContolService).Count > 0)
        //     // {
        //     //     foreach (var request in GetNextRequests(lIElevatorContolService))
        //     //     {
        //     //         //Verify if this works, if yes, then the SendRequetsToElevator method is not needed
        //     //         lIElevatorContolService.AddRequest(request);
        //     //         RemoveRequest(request);
        //     //     }
        //     //     //SendRequetsToElevator(lIElevatorContolService);
        //     // }
        // }
        // public void SubscribeToElevatorMovedEvent(IElevatorControlService elevator, EventHandler<ElevatorMovedEvent> handler)
        // {
        //     throw new NotImplementedException();
        // }




        #endregion
    }
}