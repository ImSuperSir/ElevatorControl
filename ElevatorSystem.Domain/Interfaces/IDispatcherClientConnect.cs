using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorSystem.Domain.Interfaces
{
    public interface IDispatcherClientConnect
    {
        void Connect(IElevatorControlService elevatorControlService);
    }
}