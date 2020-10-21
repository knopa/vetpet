using System.Collections.Generic;
using VetPet.Dto;

namespace VetPet.Services
{
    public interface IAnimalService
    {
        List<AnimalDto> All();
        AnimalDto Add(AnimalRequestDto model);
    }
}