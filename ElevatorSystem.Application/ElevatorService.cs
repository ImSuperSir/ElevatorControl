using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Events;
using ElevatorSystem.Domain.Interfaces;

namespace ElevatorSystem.Application
{
    public class ElevatorService : IElevatorService
    {

        private IRequestDispatcherService _PrequestDispatcherService { get; }

        public ElevatorService(IRequestDispatcherService pRequestDispatcherService)
        {
            _PrequestDispatcherService = pRequestDispatcherService;
        }

        public async Task ProcessRequest(ElevatorRequest request)
        {
            await _PrequestDispatcherService.AddRequest(request);
        }
    }
}
