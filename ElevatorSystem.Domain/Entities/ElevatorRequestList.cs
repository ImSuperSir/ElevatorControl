using System.Diagnostics;
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
                    Console.WriteLine($"Elevator Request added: {request.ToFloor} {request.Direction}, total requests: {_elevatorRequests.Count}");
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
            List<ElevatorRequest> lResultUp, lResultDown, lResultThisFloor, lResultAll;

            SetElevatorRequests(out lResultUp, out lResultDown, out lResultThisFloor, out lResultAll);

            //PrintCollectionsHelper(currentFloor, lResultUp, lResultDown, lResultAll);

            IEnumerable<ElevatorRequest> request = lResultAll.ToList(); //= _elevatorRequests.OrderBy(x => x.Direction == direction).ThenBy(x => x.Direction == oppositeDirection);

            GetNextElevatorRequestByDirection(ref direction, currentFloor, lResultAll, ref request);

            var lResultFinal = lResultThisFloor.Concat(request).ToList();

            return lResultFinal.FirstOrDefault();

        }

        private void GetNextElevatorRequestByDirection(ref ElevatorDirection direction
                                , int currentFloor
                                , List<ElevatorRequest> lResultAll
                                , ref IEnumerable<ElevatorRequest> request)
        {

            Func<ElevatorRequest, bool> floorsUpThan = x => x.ToFloor >= currentFloor && x.Direction == ElevatorDirection.Up; ;
            Func<ElevatorRequest, bool> floorsDownThan = x => x.ToFloor <= currentFloor && x.Direction == ElevatorDirection.Down;

            if (direction == ElevatorDirection.Up)
                request = request.Where(floorsUpThan).ToList();
            else if (direction == ElevatorDirection.Down)
                request = request.Where(floorsDownThan).ToList();

            if (null == request.FirstOrDefault())
            {
                request = lResultAll.ToList();
                direction = direction == ElevatorDirection.Up ? ElevatorDirection.Down : ElevatorDirection.Up;

                if (direction == ElevatorDirection.Up)
                    request = request.Where(x => x.Direction == ElevatorDirection.Up).ToList();
                else if (direction == ElevatorDirection.Down)
                    request = request.Where(x => x.Direction == ElevatorDirection.Down).ToList();
            }
        }

        private void PrintCollectionsHelper(int currentFloor
                        , List<ElevatorRequest> lResultUp
                        , List<ElevatorRequest> lResultDown
                        , List<ElevatorRequest> lResultAll)
        {
            Debug.WriteLine("Los que van para arriba");
            lResultUp.ForEach(x => Debug.WriteLine($"Request: {x.ToFloor} {x.Direction}, Desde mi piso tengo que ir: {x.GetFloorDirection(currentFloor)}, - {x.ToString()}"));
            Debug.WriteLine("Those who goes down");
            lResultDown.ForEach(x => Debug.WriteLine($"Request: {x.ToFloor} {x.Direction}, From my floor We need to go towards {x.GetFloorDirection(currentFloor)}, - {x.ToString()}"));
            Debug.WriteLine("And these are all together");
            lResultAll.ForEach(x => Debug.WriteLine($"Request: {x.ToFloor} {x.Direction}, From my floor We need to go towards {x.GetFloorDirection(currentFloor)}, - {x.ToString()}"));
        }

        private void SetElevatorRequests(out List<ElevatorRequest> lResultUp, out List<ElevatorRequest> lResultDown, out List<ElevatorRequest> lResultThisFloor, out List<ElevatorRequest> lResultAll)
        {
            lResultUp = _elevatorRequests.Where(x => x.Direction == ElevatorDirection.Up)
                                     .OrderBy(x => x.ToFloor)
                                    .ToList();
            lResultDown = _elevatorRequests.Where(x => x.Direction == ElevatorDirection.Down)
                                     .OrderByDescending(x => x.ToFloor)
                                    .ToList();
            lResultThisFloor = _elevatorRequests.Where(x => x.Direction == ElevatorDirection.None).ToList();

            lResultAll = lResultUp.Concat(lResultDown).ToList();
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