using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetPet.Models;

namespace VetPet.Dto.Profiles
{
    public partial class VetPetProfile
    {
        public void MapAnimal()
        {
            CreateMap<Animal, AnimalDto>()
                .ForMember(c => c.UserName, opt => opt.MapFrom(c => c.User.UserName));
        }
    }
}
