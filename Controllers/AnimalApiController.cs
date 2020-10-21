using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VetPet.Common;
using VetPet.Dto;
using VetPet.Models;
using VetPet.Services;

namespace VetPet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/animals")]
    [Authorize]
    [ValidateModel]
    public class AnimalApiController : ControllerBase
    {
        private readonly ILogger<AnimalApiController> _logger;
        private readonly IAnimalService _animalService;
        public AnimalApiController(
            ILogger<AnimalApiController> logger,
            IAnimalService animalService)
        {
            _logger = logger;
            _animalService = animalService;
        }

        [HttpGet]
        public IEnumerable<AnimalDto> Get()
        {
            return _animalService.All();
        }

        [HttpPost]
        public AnimalDto Post(AnimalRequestDto model)
        {
            return _animalService.Add(model);
        }
    }
}
