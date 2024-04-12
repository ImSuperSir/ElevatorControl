using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElevatorSystem.Domain.Events;

namespace ElevatorSystem.Domain.Entities
{


    public static class ElevatorRequestList 
    {
        private static readonly List<ElevatorRequest> _elevatorRequests = new List<ElevatorRequest>();
        private static readonly object _lock = new object();


        public static void AddRequest(ElevatorRequest request)
        {
            lock (_lock)
            {
                if(!_elevatorRequests.Any(x => x.Floor == request.Floor 
                                    && x.Direction == request.Direction))
                    _elevatorRequests.Add(request);
            }
        }

        public static ElevatorRequest? GetNextRequest( ElevatorDirection direction, int currentFloor)
        {
            lock (_lock)
            {
                 return _elevatorRequests.Where(x => x.Floor > currentFloor && x.Direction == direction)
                                .OrderBy(x => x.Floor)
                                .FirstOrDefault();
            }
        }

        public static void RemoveRequest(ElevatorRequest request)
        {
            lock (_lock)
            {
                _elevatorRequests.Remove(request);
            }
        }
    }
}