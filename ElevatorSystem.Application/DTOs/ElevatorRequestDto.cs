using ElevatorSystem.Domain.Events;

namespace ElevatorSystem.Application.DTOs
{
   public record ElevatorRequestDto (ElevatorDirection Direction, int Floor);
}