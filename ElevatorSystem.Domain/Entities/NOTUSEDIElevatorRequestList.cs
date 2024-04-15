// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using ElevatorSystem.Domain.Events;

// namespace ElevatorSystem.Domain.Entities
// {
//     public interface IElevatorRequestListManager
//     {
//         void AddRequest(ElevatorRequest request);
//         ElevatorRequest? GetNextRequest(ElevatorDirection direction, int currentFloor);
//         void RemoveRequest(ElevatorRequest request);
//         List<ElevatorRequest> GetSortedRequests();  //Testing or diagnostic purposes
//     }
// }