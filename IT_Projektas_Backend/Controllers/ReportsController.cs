using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_Projektas_Backend.Services.AuthService;
using Swashbuckle.AspNetCore.Swagger;
using IT_Projektas_Backend.Responses;
using IT_Projektas_Backend.RequestModels;
using System.Net;
using IT_Projektas_Backend.RequestModels.AuthRequestModels;
using IT_Projektas_Backend.Services.ReportsService;
using IT_Projektas_Backend.Responses.ReportsResponses;

namespace IT_Projektas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {

        private readonly it_projektasContext _context;
        private readonly IReportsService _reportsService;
        public ReportsController(it_projektasContext context, IReportsService reportsService)
        {
            _context = context;
            _reportsService = reportsService;
        }

        [HttpPost("getPositionsReport")]

        public async Task<IActionResult> PositionsResults()
        {
            var list = await _reportsService.PositionsReport();
            return Ok(list);
        }


        [HttpPost("personalWorkReport")]
        public async Task<IActionResult> personalWorkReport(string profileID)
        {
            int profID = int.Parse(profileID);
            PersonalResponse personal = await _reportsService.PersonalReport(profID);
            return Ok(personal);
        }

        [HttpGet("getAllWorkers")]
        public async Task<IActionResult> GetWorkers()
        {
            var list = await _reportsService.GetWorkers();
            return Ok(list);
        }
    }
}
