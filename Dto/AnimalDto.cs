using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPet.Models.Enum;

namespace VetPet.Dto
{
    public class AnimalDto
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public AnimalType Type { get; set; }

        public string TypeName => Type.ToString();

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime Created { get; set; }
    }
}
