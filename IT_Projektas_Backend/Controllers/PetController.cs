using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using IT_Projektas_Backend.Services.AnimalService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Projektas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetService _animalService;

        public PetController(IPetService animalService)
        {
            _animalService = animalService;
        }

        [HttpPost]
        public IActionResult AddAnimal(PetRequest addAnimalRequest)
        {
            var obj = _animalService.AddPet(addAnimalRequest);
            return Ok(obj);
        }
    }
}