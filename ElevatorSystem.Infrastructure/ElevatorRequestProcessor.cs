using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Application;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Events;
using Microsoft.Extensions.Hosting;

namespace ElevatorSystem.Infrastructure
{
    public class ElevatorRequestProcessor : BackgroundService
    {
        private readonly IElevatorService _elevatorService;
        private readonly Elevator _elevator;

        public ElevatorRequestProcessor(IElevatorService elevatorService, Elevator elevator)
        {
            Console.WriteLine("ElevatorRequestProcessor created");
            _elevatorService = elevatorService;
            _elevator = elevator;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var elevatorRequest =  ElevatorRequestList.GetNextRequest( ElevatorDirection.Up,1); //_elevator.Direction, _elevator.CurrentFloor);
                // if(elevatorRequest != null)
                // {
                //await _elevator.MoveToFloor(elevatorRequest.Floor);
                //      System.Threading.Thread.Sleep(10000); //Simulating the time taken to process the request

                //    await Task.CompletedTask; //Simulating the time taken to process the request
                // }
                // System.Threading.Thread.Sleep(10000); //Simulating the time taken to process the request

                
                await Task.Delay(1000, stoppingToken);
            }
        }

    }
}