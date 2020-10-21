using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace VetPet.Dto.Profiles
{
    public partial class VetPetProfile : Profile
    {
        public VetPetProfile()
        {
            MapAnimal();
        }
    }
}
