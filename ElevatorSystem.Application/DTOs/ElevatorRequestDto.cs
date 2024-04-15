using System.ComponentModel.DataAnnotations;
using ElevatorSystem.Domain.Enums;
using ElevatorSystem.Utils;


namespace ElevatorSystem.Application.DTOs
{
   public record ElevatorInsideRequestDto(
       [Required]
       [Range(1, 5, ErrorMessage = "Invalid floor (1-5)")]
       int Floor
       );
   public record ElevatorOutsideRequestDto(

     [Required]
     [EnumValidation(typeof(RequestDirection), ErrorMessage = "Invalid direction (1-2)")]
     RequestDirection Direction
   ,
     [Required]
     [Range(1, 5, ErrorMessage = "Invalid floor (1-5)")]
   int FromFloor);
}