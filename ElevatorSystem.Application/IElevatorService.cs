using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Events;

namespace ElevatorSystem.Application
{
    public interface IElevatorService
    {
        Task ProcessRequest(ElevatorRequest request);
    }
}