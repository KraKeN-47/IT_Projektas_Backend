using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.PictureRequestModels;
using IT_Projektas_Backend.Responses.InventorResponses;
using IT_Projektas_Backend.Services.InventorService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Projektas_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class InventorController : ControllerBase
    {      

        private readonly it_projektasContext _context;
        private readonly IInventorService _inventorService;
        public InventorController(it_projektasContext context, IInventorService inventorService)
        {
            _context = context;
            _inventorService = inventorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInventor()
        {
           var list = await _inventorService.GetInventor();
            return Ok(list);
        }
    }
}
