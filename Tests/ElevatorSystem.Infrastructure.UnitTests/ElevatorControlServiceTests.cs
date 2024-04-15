using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Enums;

namespace ElevatorSystem.Infrastructure.UnitTests;

public class ElevatorRequestListTests
{
    [Fact]
    public void GetNextRequest_ReturnsRequest_WhenRequestsExist()
    {
        // Arrange
        var elevatorRequestList = new ElevatorRequestList();
        var request1 = new ElevatorRequest(4, ElevatorDirection.Down);
        elevatorRequestList.AddRequest(request1);

       // Act
        var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Up, 1);

        // Assert
        Assert.Equal(request1, result);
    }

    // [Fact]
    // public void GetNextRequest_ReturnsNull_WhenNoRequestsExist()
    // {
    //     // Arrange
    //     var elevatorRequestList = new ElevatorRequestList();

    //     // Act
    //     var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Up, 0);

    //     // Assert
    //     Assert.Null(result);
    // }

    // [Fact]
    // public void GetNextRequest_ReturnsNull_WhenNoMatchingRequestsExist()
    // {
    //     // Arrange
    //     var elevatorRequestList = new ElevatorRequestList();
    //     var request1 = new ElevatorRequest(1, ElevatorDirection.Up);
    //     elevatorRequestList.AddRequest(request1);

    //     // Act
    //     var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Down, 0);

    //     // Assert
    //     Assert.Null(result);
    // }
}