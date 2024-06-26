using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using ElevatorSystem.Domain.Events;
using ElevatorSystem.Domain.Enums;
using System.Security.Cryptography.X509Certificates;

namespace ElevatorSystem.Infrastructure
{

    public enum ElevatorLimits
    {
        MinFloor = 1,
        MaxFloor = 5
    }
    public class ElevatorControlService : BackgroundService, IElevatorControlService
    {

        #region Properties

        public Guid Id { get; init; }
        ElevatorRequestList ElevatorCommands { get; }

        #endregion

        public ElevatorControlService(IDispatcherClientConnect pIDispatcherClientConnect)
        {
            Id = Guid.NewGuid();
            Direction = ElevatorDirection.Up;  //Initial floor is 1
            ElevatorCommands = new ElevatorRequestList();

            Console.WriteLine($"ElevatorControlService: {Id}, created {System.DateTime.UtcNow.ToString()}");
            pIDispatcherClientConnect.Connect((IElevatorControlService)this);

        }


        #region BackgroundService
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(5000);
            while (!stoppingToken.IsCancellationRequested)
            {
                //  Console.WriteLine($"Elevator:{Id.ToString().Substring(30)} has: {ElevatorCommands.Count} request to attend");   

                ElevatorRequest? nextRequest = ElevatorCommands.GetNextRequest(Direction, CurrentFloor);
                if (nextRequest != null)
                {
                    Direction = nextRequest.GetFloorDirection(CurrentFloor);
                    MoveOneStep(nextRequest.NextFloor(CurrentFloor));  //just move one floor
                    if (CurrentFloor == nextRequest.ToFloor)
                    {
                        OpenDoor();
                        RemoveRequestDone(nextRequest);
                    }
                }
                else
                {
                    // Console.WriteLine($"No request found, Current Floor :{CurrentFloor }, waiting for 5 seconds");
                }
                await Task.Delay(2000);
            }


            return; // Task.CompletedTask;
        }

        #endregion


        #region IElevatorControlService


        public int CurrentFloor { get; private set; } = 1;
        public ElevatorDirection Direction { get; private set; }


        public event ElevatorMovedEventHandler? OnElevatorMovedEvent;


        public void AddRequests(List<ElevatorRequest> requestList)
        {
            requestList.ForEach( x => 
            { 
                if (x.RequestSource == RequestFrom.Inside) 
                { 
                    x.FromFloor = CurrentFloor;
                    x.Direction = x.GetFloorDirection(CurrentFloor) ;  
                }
                });
            ElevatorCommands.AddRequestRange(requestList);
        }

        public void MoveOneStep(int floor)
        {

            if(floor == CurrentFloor)
                         return;
            
            Console.WriteLine($"Direction:{Direction.ToString()}, floor:{CurrentFloor}, Moving to floor {floor}");
            Task.Delay(5000).Wait();
            CurrentFloor = floor;
            Console.WriteLine($"Direction:{Direction.ToString()}, arrived to floor {CurrentFloor}");
            //OnElevatorMovedToFloot(this, floor);
            //OnElevatorMovedEvent?.Invoke(this, new ElevatorMovedEvent(floor));

        }


        public void OpenDoor()
        {
            Console.WriteLine($"Direction:{Direction.ToString()}, floor:{CurrentFloor}, Door is opening ");
            Task.Delay(5000).Wait();
            Console.WriteLine($"Direction:{Direction.ToString()}, floor:{CurrentFloor}, Door is closing ");

            if(CurrentFloor == (int)ElevatorLimits.MaxFloor)
            {
                Direction = ElevatorDirection.Down;
            }
            else if(CurrentFloor == (int)ElevatorLimits.MinFloor)
            {
                Direction = ElevatorDirection.Up;
            }
           
  
        }


        public void RemoveRequestDone(ElevatorRequest requestDone)
        {
            RemoveRequestList(new List<ElevatorRequest> { requestDone });
        }

        public void RemoveRequestList(List<ElevatorRequest> requestList)
        {
            ElevatorCommands.RemoveRequests(requestList);
        }




        private void OnElevatorMovedToFloot(object sender, ElevatorMovedEvent pElevatorMovedEvent)
        {
            OnElevatorMovedEvent?.Invoke(sender, pElevatorMovedEvent);
        }

        #endregion







    }
}