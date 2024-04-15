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


        public List<ElevatorRequest> GetAllRequests()
        {
            lock (_lock)
            {
                return _elevatorRequests.ToList();
            }
        }
  

        public ElevatorRequest? GetNextRequest(ElevatorDirection direction, int currentFloor)
        {

            Func<ElevatorRequest, bool> floorsUpThan = x => x.ToFloor > currentFloor;
            Func<ElevatorRequest, bool> floorsDownThan = x => x.ToFloor < currentFloor;

            ElevatorDirection oppositeDirection =
                            direction == ElevatorDirection.Up ? ElevatorDirection.Down : ElevatorDirection.Up;

            IEnumerable<ElevatorRequest> request = _elevatorRequests.OrderBy(x => x.Direction == direction).ThenBy(x => x.Direction == oppositeDirection);

            if (direction == ElevatorDirection.Up)
            {
                request = request.Where(floorsUpThan);
            }
            else if (direction == ElevatorDirection.Down)
            {
                request = request.Where(floorsDownThan);
            }


            return request.FirstOrDefault();
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