using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using IT_Projektas_Backend.Responses.ReportsResponses;
using IT_Projektas_Backend.Services.AuthService;
using IT_Projektas_Backend.Services.ClientService;
using IT_Projektas_Backend.Services.ReportsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IT_Projektas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IReportsService _reportsService;
        public ClientController(IClientService service, IReportsService reportsService)
        {
            _clientService = service;
            _reportsService = reportsService;
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

            var listWithReports = new List<WorkerWithReport>();

            foreach (var item in list)
            {
                var report = await _reportsService.PersonalReport(item.Id);
                listWithReports.Add(new WorkerWithReport
                {
                    Id = item.Id,
                    Adresas = item.Adresas,
                    AsmensKodas = item.AsmensKodas,
                    isAdmin = item.isAdmin,
                    Pastas = item.Pastas,
                    Pavarde = item.Pavarde,
                    Pozicija = item.Pozicija,
                    TelefonoNr = item.TelefonoNr,
                    Vardas = item.Vardas,
                    Report = report
                });
            }

            return Ok(listWithReports);
        }
    }
}