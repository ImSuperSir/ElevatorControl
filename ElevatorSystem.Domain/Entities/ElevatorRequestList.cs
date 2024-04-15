using ElevatorSystem.Domain.Enums;

namespace ElevatorSystem.Domain.Entities
{


    public class ElevatorRequestList
    {
        private readonly List<ElevatorRequest> _elevatorRequests;
        private readonly object _lock = new object();

        public ElevatorRequestList()
        {
            _elevatorRequests = new List<ElevatorRequest>();
        }


        public int Count
        {
            get
            {
                lock (_lock)
                {
                    return _elevatorRequests.Count;
                }
            }
        }
        private void Add(ElevatorRequest request)
        {
            lock (_lock)
            {
                if (!_elevatorRequests.Any(x => x.ToFloor == request.ToFloor
                                    && x.Direction == request.Direction))
                {
                    _elevatorRequests.Add(request);
                    Console.WriteLine($"Request added: {request.ToFloor} {request.Direction}, total requests: {_elevatorRequests.Count}");
                }
                else
                {
                    Console.WriteLine($"Request already exists: {request.ToFloor} {request.Direction}");
                }

            }
        }
        public void AddRequest(ElevatorRequest pRequest)
        {
            Add(pRequest);
        }
        public void AddRequestRange(List<ElevatorRequest> pRequests)
        {
            pRequests.ForEach(request => Add(request));
        }

        private IEnumerable<ElevatorRequest> GetFilteredAndOrderedRequests(ElevatorDirection direction, int currentFloor)
        {
            IEnumerable<ElevatorRequest> requests = _elevatorRequests.Where(x => x.Direction == direction);

            if (direction == ElevatorDirection.Down)
            {
                requests = requests.Where(x => x.ToFloor <= currentFloor)
                                   .OrderByDescending(x => x.ToFloor);
            }
            else if (direction == ElevatorDirection.Up)
            {
                requests = requests.Where(x => x.ToFloor >= currentFloor)
                                   .OrderBy(x => x.ToFloor);
            }

            return requests;
        }

        public List<ElevatorRequest> GetAllRequests()
        {
            lock (_lock)
            {
                return _elevatorRequests.ToList();
            }
        }
        public List<ElevatorRequest> GetAllNextRequest(ElevatorDirection direction, int currentFloor)
        {
            lock (_lock)
            {
                return GetFilteredAndOrderedRequests(direction, currentFloor).ToList();
            }
        }

        public ElevatorRequest? GetNextRequest(ElevatorDirection direction, int currentFloor)
        {
            lock (_lock)
            {
                return GetFilteredAndOrderedRequests(direction, currentFloor).FirstOrDefault();
            }
        }

        private void Remove(ElevatorRequest pRequest)
        {
            lock (_lock)
            {
                _elevatorRequests.Remove(pRequest);
            }
        }

        public void RemoveRequests(List<ElevatorRequest> pRequests)
        {
            pRequests.ForEach(request => Remove(request));
        }
    }
}