using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_Projektas_Backend.Services.ServiRegistrationService;
using IT_Projektas_Backend.RequestModels.ServiRegRequestModels;
using IT_Projektas_Backend.Models;

namespace IT_Projektas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRegController : ControllerBase
    {
        private readonly it_projektasContext _context;
        private readonly IServiRegService _serviRegService;

        public ServiceRegController(it_projektasContext context, IServiRegService _serviceRegService)
        {
            _context = context;
            _serviRegService = _serviceRegService;
        }
        [HttpGet("getRegServices/{id}")]
        public async Task<IActionResult> GetRegServices(string id)
        {
            int iden = int.Parse(id);
            ServiRegGetRequest req = new ServiRegGetRequest { Id = iden };
            var obj = await _serviRegService.BuildServicesGetRegRequest(req);
            return Ok(obj);
        }
        [HttpDelete("DeleteRegService/{id}")]
        public async Task<IActionResult> DelRegService(string id)
        {
            int iden = int.Parse(id);
            var reg = await _context.PaslaugosRezervacija.Where(x => x.Id == iden).FirstOrDefaultAsync();
            _context.PaslaugosRezervacija.Remove(reg);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("AddRegService")]
        public IActionResult AddReservation([FromBody] ServiRegAddRequest request)
        {
            var obj = _serviRegService.BuildServicesAddRegRequest(request);
            _context.SaveChanges();
            return Ok();
        }
    }
}
