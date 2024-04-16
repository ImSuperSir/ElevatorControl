using System.Diagnostics;
using System.Runtime.InteropServices;
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

    [Fact]
    public void GetNextRequest_CurrentFloorOneGoAllFloorsUpAndDown_MusttGoUpAndThenDown()
    {
        var elevatorRequestList = new ElevatorRequestList();
        var request1 = new ElevatorRequest(1, ElevatorDirection.Up);
        var request2 = new ElevatorRequest(2, ElevatorDirection.Up);
        var request3 = new ElevatorRequest(3, ElevatorDirection.Up);
        var request4 = new ElevatorRequest(4, ElevatorDirection.Up);
        var request5 = new ElevatorRequest(5, ElevatorDirection.Down);
        var request4d = new ElevatorRequest(4, ElevatorDirection.Down);
        var request3d = new ElevatorRequest(3, ElevatorDirection.Down);
        var request2d = new ElevatorRequest(2, ElevatorDirection.Down);



        elevatorRequestList.AddRequest(request1);
        elevatorRequestList.AddRequest(request2);
        elevatorRequestList.AddRequest(request3);
        elevatorRequestList.AddRequest(request4);
        elevatorRequestList.AddRequest(request5);
        elevatorRequestList.AddRequest(request4d);
        elevatorRequestList.AddRequest(request3d);
        elevatorRequestList.AddRequest(request2d);

        // Act
        var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Up, 1);
        // Assert
        Assert.Equal(request1, result);
    }

    [Fact]

    public void GetNextRequest_CurrentFloorOneGoAllFloorsUpAndDown_MusttGoUpFloorTwo()
    {
        var elevatorRequestList = new ElevatorRequestList();
        // var request1 = new ElevatorRequest(1, ElevatorDirection.Up);
        var request2 = new ElevatorRequest(2, ElevatorDirection.Up);
        var request3 = new ElevatorRequest(3, ElevatorDirection.Up);
        var request4 = new ElevatorRequest(4, ElevatorDirection.Up);
        var request5 = new ElevatorRequest(5, ElevatorDirection.Down);
        var request4d = new ElevatorRequest(4, ElevatorDirection.Down);
        var request3d = new ElevatorRequest(3, ElevatorDirection.Down);
        var request2d = new ElevatorRequest(2, ElevatorDirection.Down);



        // elevatorRequestList.AddRequest(request1);
        elevatorRequestList.AddRequest(request2);
        elevatorRequestList.AddRequest(request3);
        elevatorRequestList.AddRequest(request4);
        elevatorRequestList.AddRequest(request5);
        elevatorRequestList.AddRequest(request4d);
        elevatorRequestList.AddRequest(request3d);
        elevatorRequestList.AddRequest(request2d);

        // Act
        var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Up, 1);
        // Assert
        Assert.Equal(request2, result);
    }

    [Fact]

    public void GetNextRequest_CurrentFloorTwoGoGoUp_MusttGetFloorThree()
    {
        var elevatorRequestList = new ElevatorRequestList();
        var request1 = new ElevatorRequest(1, ElevatorDirection.Up);
        //var request2 = new ElevatorRequest(2, ElevatorDirection.Up);
        var request3 = new ElevatorRequest(3, ElevatorDirection.Up);
        var request4 = new ElevatorRequest(4, ElevatorDirection.Up);
        var request5 = new ElevatorRequest(5, ElevatorDirection.Down);
        var request4d = new ElevatorRequest(4, ElevatorDirection.Down);
        var request3d = new ElevatorRequest(3, ElevatorDirection.Down);
        var request2d = new ElevatorRequest(2, ElevatorDirection.Down);



        elevatorRequestList.AddRequest(request1);
        //elevatorRequestList.AddRequest(request2);
        elevatorRequestList.AddRequest(request3);
        elevatorRequestList.AddRequest(request4);
        elevatorRequestList.AddRequest(request5);
        elevatorRequestList.AddRequest(request4d);
        elevatorRequestList.AddRequest(request3d);
        elevatorRequestList.AddRequest(request2d);

        // Act
        var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Up, 2);
        // Assert
        Assert.Equal(request3, result);
    }



    [Fact]

    public void GetNextRequest_CurrentThreeGoGoUp_MusttGetFloorFour()
    {
        var elevatorRequestList = new ElevatorRequestList();
        var request1 = new ElevatorRequest(1, ElevatorDirection.Up);
        var request2 = new ElevatorRequest(2, ElevatorDirection.Up);
        // var request3 = new ElevatorRequest(3, ElevatorDirection.Up);
        var request4 = new ElevatorRequest(4, ElevatorDirection.Up);
        var request5 = new ElevatorRequest(5, ElevatorDirection.Down);
        var request4d = new ElevatorRequest(4, ElevatorDirection.Down);
        var request3d = new ElevatorRequest(3, ElevatorDirection.Down);
        var request2d = new ElevatorRequest(2, ElevatorDirection.Down);



        elevatorRequestList.AddRequest(request1);
        elevatorRequestList.AddRequest(request2);
        // elevatorRequestList.AddRequest(request3);
        elevatorRequestList.AddRequest(request4);
        elevatorRequestList.AddRequest(request5);
        elevatorRequestList.AddRequest(request4d);
        elevatorRequestList.AddRequest(request3d);
        elevatorRequestList.AddRequest(request2d);

        // Act
        var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Up, 3);
        // Assert
        Assert.Equal(request4, result);
    }


    [Fact]

    public void GetNextRequest_CurrentFourGoGoUp_MusttGetFloorFive()
    {
        var elevatorRequestList = new ElevatorRequestList();
        var request1 = new ElevatorRequest(1, ElevatorDirection.Up);
        var request2 = new ElevatorRequest(2, ElevatorDirection.Up);
        var request3 = new ElevatorRequest(3, ElevatorDirection.Up);
        // var request4 = new ElevatorRequest(4, ElevatorDirection.Up);
        var request5 = new ElevatorRequest(5, ElevatorDirection.Down);
        var request4d = new ElevatorRequest(4, ElevatorDirection.Down);
        var request3d = new ElevatorRequest(3, ElevatorDirection.Down);
        var request2d = new ElevatorRequest(2, ElevatorDirection.Down);



        elevatorRequestList.AddRequest(request1);
        elevatorRequestList.AddRequest(request2);
        elevatorRequestList.AddRequest(request3);
        // elevatorRequestList.AddRequest(request4);
        elevatorRequestList.AddRequest(request5);
        elevatorRequestList.AddRequest(request4d);
        elevatorRequestList.AddRequest(request3d);
        elevatorRequestList.AddRequest(request2d);

        // Act
        var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Up, 4);
        // Assert
        Assert.Equal(request5, result);
    }

    [Fact]

    public void GetNextRequest_CurrentFiveGoDown_MusttGetFloorFoor()
    {
        var elevatorRequestList = new ElevatorRequestList();
        var request1 = new ElevatorRequest(1, ElevatorDirection.Up);
        var request2 = new ElevatorRequest(2, ElevatorDirection.Up);
        var request3 = new ElevatorRequest(3, ElevatorDirection.Up);
        var request4 = new ElevatorRequest(4, ElevatorDirection.Up);
        // var request5 = new ElevatorRequest(5, ElevatorDirection.Down);
        var request4d = new ElevatorRequest(4, ElevatorDirection.Down);
        var request3d = new ElevatorRequest(3, ElevatorDirection.Down);
        var request2d = new ElevatorRequest(2, ElevatorDirection.Down);



        elevatorRequestList.AddRequest(request1);
        elevatorRequestList.AddRequest(request2);
        elevatorRequestList.AddRequest(request3);
        elevatorRequestList.AddRequest(request4);
        // elevatorRequestList.AddRequest(request5);
        elevatorRequestList.AddRequest(request4d);
        elevatorRequestList.AddRequest(request3d);
        elevatorRequestList.AddRequest(request2d);

        // Act
        var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Down, 5);
        // Assert
        Assert.Equal(request4d, result);
    }


      #region Do not delete

    [Fact(Skip = "Skipping this test temporarily due to debugging test.")]
    public void ManualTesting()  //DO NOT DELETE
    {


        var elevatorRequestList = new ElevatorRequestList();
        var request1 = new ElevatorRequest(1, ElevatorDirection.Up);
        var request2 = new ElevatorRequest(2, ElevatorDirection.Up);
        var request3 = new ElevatorRequest(3, ElevatorDirection.Up);
        var request4 = new ElevatorRequest(4, ElevatorDirection.Up);
        var request5 = new ElevatorRequest(5, ElevatorDirection.Down);
        var request4d = new ElevatorRequest(4, ElevatorDirection.Down);
        var request3d = new ElevatorRequest(3, ElevatorDirection.Down);
        var request2d = new ElevatorRequest(2, ElevatorDirection.Down);



        elevatorRequestList.AddRequest(request1);
        elevatorRequestList.AddRequest(request2);
        elevatorRequestList.AddRequest(request3);
        elevatorRequestList.AddRequest(request4);
        elevatorRequestList.AddRequest(request5);
        elevatorRequestList.AddRequest(request4d);
        elevatorRequestList.AddRequest(request3d);
        elevatorRequestList.AddRequest(request2d);

        int currentFloor = 1;
        ElevatorDirection direction = ElevatorDirection.Up;

        Func<ElevatorRequest, bool> floorsUpThan = x => x.ToFloor >= currentFloor;
        Func<ElevatorRequest, bool> floorsDownThan = x => x.ToFloor <= currentFloor;

        ElevatorDirection oppositeDirection =
                        direction == ElevatorDirection.Up ? ElevatorDirection.Down : ElevatorDirection.Up;

        var lResultUp = elevatorRequestList.GetAllRequests().Where(x => x.Direction == ElevatorDirection.Up)
                                 .OrderBy(x => x.ToFloor)
                                .ToList();

        var lResultDown = elevatorRequestList.GetAllRequests().Where(x => x.Direction == ElevatorDirection.Down)
                                 .OrderByDescending(x => x.ToFloor)
                                .ToList();

        var lResultAll = lResultUp.Concat(lResultDown).ToList();

        Debug.WriteLine("Los que van para arriba");
        lResultUp.ForEach(x => Debug.WriteLine($"Request: {x.ToFloor} {x.Direction}, Desde mi piso tengo que ir: {x.GetFloorDirection(currentFloor)}, - {x.ToString()}"));
        Debug.WriteLine("Those who goes down");
        lResultDown.ForEach(x => Debug.WriteLine($"Request: {x.ToFloor} {x.Direction}, From my floor We need to go towards {x.GetFloorDirection(currentFloor)}, - {x.ToString()}"));
        Debug.WriteLine("And these are all together");
        lResultAll.ForEach(x => Debug.WriteLine($"Request: {x.ToFloor} {x.Direction}, From my floor We need to go towards {x.GetFloorDirection(currentFloor)}, - {x.ToString()}"));

        // Act
        var result = elevatorRequestList.GetNextRequest(ElevatorDirection.Down, 5);
        // Assert
        Assert.Equal(request2, result);
    }

    #endregion    
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