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
        private readonly IPetService _petService;

        public PetController(IPetService animalService)
        {
            _petService = animalService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPets()
        {
            var obj = await _petService.GetPets();
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserPets(int id)
        {
            var list = await _petService.GetUserPets(id);
            return Ok(list);
        }
        [HttpPost]
        public IActionResult AddPet(PetRequest addAnimalRequest)
        {
            var obj = _petService.AddPet(addAnimalRequest);
            return Ok(obj);
        }
        [HttpDelete("{id}")]
        public IActionResult RemovePet(int id)
        {
            _petService.RemovePet(id);
            return Ok();
        }
    }
}