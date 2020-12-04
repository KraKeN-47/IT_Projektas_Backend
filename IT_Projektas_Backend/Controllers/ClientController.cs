using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using IT_Projektas_Backend.Services.AuthService;
using IT_Projektas_Backend.Services.ClientService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Projektas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService service)
        {
            _clientService = service;
        }
        [HttpGet("clients")]
        public async Task<IActionResult> GetClients()
        {
            var list = await _clientService.GetClients();
            return Ok(list);
        }
        [HttpGet("workers")]
        public async Task<IActionResult> GetWorkers()
        {
            var list = await _clientService.GetWorkers();
            return Ok(list);
        }
    }
}