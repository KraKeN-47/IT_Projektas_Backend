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
        [HttpPost]
        public async Task<IActionResult> AddServices(ServiAddRequest request)
        {
            Paslaugos addRequest = _serviService.BuildServicesAddRequest(request);
            return Ok(addRequest);
        }

        [HttpGet]
        public async Task<IActionResult> GetServices()
        {
            var list = await _serviService.BuildServicesGetRequest();
            return Ok(list);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteService(ServiRemoveRequest rmRequest)
        {
            int id = rmRequest.Id;
            var service = await _context.Paslaugos.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.Paslaugos.Remove(service);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
