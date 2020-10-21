using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using VetPet.Dto;
using VetPet.Models;
using VetPet.Repository;

namespace VetPet.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly string _userId;

        public AnimalService(
            IUnitOfWork uow,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _uow = uow;
            _mapper = mapper;
            _userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public List<AnimalDto> All()
        {
            List<Animal> animals = _uow.AnimalRepository.List().list;
            return _mapper.Map<List<AnimalDto>>(animals);
        }

        public AnimalDto Add(AnimalRequestDto model)
        {
            if (model == null)
            {
                return null;
            }

            Animal animal = new Animal()
            {
                Name = model.Name?.Trim(),
                Type = model.Type,
                UserId = _userId
            };
            _uow.AnimalRepository.Create(animal);

            return _mapper.Map<AnimalDto>(animal);
        }
    }
}
