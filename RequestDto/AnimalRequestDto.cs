using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VetPet.Common;
using VetPet.Models.Enum;

namespace VetPet.Dto
{
    public class AnimalRequestDto
    {
        [MaxLength(Constants.AttributeValidation.DefaultLength100)]
        public string Name { get; set; }

        [RequiredEnumField(ErrorMessage = "Type is required")]
        public AnimalType Type { get; set; }
    }
}
