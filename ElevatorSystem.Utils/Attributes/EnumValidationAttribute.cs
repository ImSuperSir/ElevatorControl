using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElevatorSystem.Utils
{
    public class EnumValidationAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public EnumValidationAttribute(Type enumType)
        {
            _enumType = enumType;
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Type must be an enum");
            }
        }

        public override bool IsValid(object? value)
        {
            if (value == null) return false;
            return Enum.IsDefined(_enumType, value);
        }
    }
}