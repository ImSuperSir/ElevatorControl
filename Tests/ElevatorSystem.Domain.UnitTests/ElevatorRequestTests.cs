
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Enums;

namespace ElevatorSystem.Domain.UnitTests;

public class ElevatorRequestTests
{
    [Fact]
    public void NextFloor_WhenDirectionIsUpAndCurrentFloorIsOneAndGoesToFloorOne_ReturnsOne()
    {
        // Arrange
        int currentFloor = 1;
        int toFloor = 1;
        ElevatorRequest elevatorRequest = new ElevatorRequest(toFloor, ElevatorDirection.Up);

        // Act
        int nextFloor = elevatorRequest.NextFloor(currentFloor);

        // Assert
        Assert.Equal(currentFloor, nextFloor);
    }

    [Fact]
    public void NextFloor_WhenDirectionIsDownAndCurrentFloorIsFiveAndGoesToFloorFive_ReturnsFive()
    {
        // Arrange
        int currentFloor = 5;
        int toFloor = 5;
        ElevatorRequest elevatorRequest = new ElevatorRequest(toFloor, ElevatorDirection.Down);

        // Act
        int nextFloor = elevatorRequest.NextFloor(currentFloor);

        // Assert
        Assert.Equal(currentFloor, nextFloor);
    }

    [Fact]
    public void NextFloor_WhenDirectionIsDownAndCurrentFloorIsFiveAndGoesToFloorOne_ReturnsFour()
    {
        // Arrange
        int currentFloor = 5;
        int toFloor = 1;
        ElevatorRequest elevatorRequest = new ElevatorRequest(toFloor, ElevatorDirection.Down);

        // Act
        int nextFloor = elevatorRequest.NextFloor(currentFloor);

        // Assert
        Assert.Equal(4, nextFloor);
    }

    [Fact]
    public void NextFloor_WhenDirectionIsUpAndCurrentFloorIsOneAndGoesToFloorFive_ReturnsTwo()
    {
        // Arrange
        int currentFloor = 1;
        int toFloor = 5;
        ElevatorRequest elevatorRequest = new ElevatorRequest(toFloor, ElevatorDirection.Up);

        // Act
        int nextFloor = elevatorRequest.NextFloor(currentFloor);

        // Assert
        Assert.Equal(2, nextFloor);
    }


    [Fact]
    public void NextFloor_WhenDirectionIsUpAndCurrentFloorIsMinorThanToFloor_ReturnsCurrentFloorPlusOne()
    {
        // Arrange
        int currentFloor = 2;
        int toFloor = 4;
        ElevatorRequest elevatorRequest = new ElevatorRequest(toFloor, ElevatorDirection.Up);

        // Act
        int nextFloor = elevatorRequest.NextFloor(currentFloor);

        // Assert
        Assert.Equal(currentFloor + 1, nextFloor);
    }

    [Fact]
    public void NextFloor_WhenDirectionIsDownAndCurrentFloorIsGreatherThanToFloor_ReturnsCurrentFloorMinusOne()
    {
        // Arrange
        int currentFloor = 4;
        int toFloor = 2;
        ElevatorRequest elevatorRequest = new ElevatorRequest(toFloor, ElevatorDirection.Down);

        // Act
        int nextFloor = elevatorRequest.NextFloor(currentFloor);

        // Assert
        Assert.Equal(currentFloor - 1, nextFloor);
    }


}