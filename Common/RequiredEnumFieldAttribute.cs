using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VetPet.Common
{
    public class RequiredEnumFieldAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var type = value.GetType();
            return type.IsEnum && Enum.IsDefined(type, value);
        }
    }
}
