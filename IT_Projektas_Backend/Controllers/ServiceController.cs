using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.Responses.ServResponses;
using IT_Projektas_Backend.Services.ServiService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_Projektas_Backend.RequestModels.ServiRequestModels;


namespace IT_Projektas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ServiceController : ControllerBase
    {
        private readonly it_projektasContext _context;
        private readonly IServicesService _serviService;

        public ServiceController(it_projektasContext context, IServicesService _serviceService)
        {
            _context = context;
            _serviService = _serviceService;
        }
        [HttpPost("Addservice")]
        public async Task<IActionResult> AddService([FromBody] ServiAddRequest request)
        {
            Paslaugos addRequest = _serviService.BuildServicesAddRequest(request);
            return Ok(addRequest);
        }

        [HttpGet("Getservices")]
        public async Task<IActionResult> GetServices()
        {
            var list = await _serviService.BuildServicesGetRequest();
            return Ok(list);
        }
        [HttpDelete("DeleteService/{id}")]
        public async Task<IActionResult> DeleteService(string id)
        {
            int idpar = int.Parse(id);
            var service = await _context.Paslaugos.Where(x => x.Id == idpar).FirstOrDefaultAsync();
            _context.Paslaugos.Remove(service);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("Updateservice")]

        public async Task<IActionResult> UpdateService([FromBody] ServiUpdateRequest upRequest)
        {
            var service = await _context.Paslaugos.Where(x => x.Id == upRequest.Id).FirstOrDefaultAsync();
            service.Pavadinimas = upRequest.Pavadinimas;
            service.Rizika = upRequest.Rizika;
            service.Kaina = upRequest.Kaina;
            service.Aprasymas = upRequest.Aprasymas;
            service.Narkoze = upRequest.Narkoze;
            service.Trukme = upRequest.Trukme;
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
