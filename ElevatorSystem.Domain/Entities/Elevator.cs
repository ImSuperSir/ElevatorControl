using System.Collections.Concurrent;
using System.Linq.Expressions;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Events;

public delegate void OnElevatorMovedHandler(ElevatorMovedEvent elevatorMovedEvent);
public class Elevator
{

    
    public event OnElevatorMovedHandler? ElevatorMoved;

    public int CurrentFloor { get; private set; } = 1;
    public ElevatorDirection Direction { get; private set; } = ElevatorDirection.Stationary;

    ConcurrentQueue<ElevatorRequest> Requests { get; init; } = new();
    public Elevator()
    {
    }


    public void AddRequest(ElevatorRequest request)
    {
        Requests.Enqueue(request);
    }

    public Task<bool> MoveToFloor(int floor)
    {
        if (floor == CurrentFloor)
        {
            // Optionally handle the case where the elevator is already at the requested floor
            return Task.FromResult(false);
        }

        Direction = floor > CurrentFloor ? ElevatorDirection.Up : ElevatorDirection.Down;
        Console.WriteLine($"Elevator is moving to floor {floor}.");
        // Task.Delay(10000).Wait(); //Simulating the movement of the elevator
        
        CurrentFloor = floor;

        // Raise the ElevatorMoved event after moving to a new floor.
        OnElevatorMoved(new ElevatorMovedEvent(floor));

        return Task.FromResult(true);
    }

    // Method to trigger the ElevatorMoved event
    protected virtual void OnElevatorMoved(ElevatorMovedEvent elevatorMovedEvent)
    {
        Console.WriteLine($"Elevator has moved to floor {elevatorMovedEvent.NewFloor}.");
        ElevatorMoved?.Invoke(elevatorMovedEvent);
    }

}