using ElevatorSystem.Domain.Enums;


namespace ElevatorSystem.Application.DTOs
{
   public record ElevatorInsideRequestDto(ElevatorDirection Direction, int Floor);
   public record ElevatorOutSideRequestDto(ElevatorDirection Direction, int Floor);
}