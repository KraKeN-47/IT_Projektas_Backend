using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.InventorRequestModels;
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
    public class InventorReservationController : ControllerBase
    {

        private readonly it_projektasContext _context;
        private readonly IInventorResrvationService _inventorReservationService;
        public InventorReservationController(it_projektasContext context, IInventorResrvationService inventorReservationService)
        {
            _context = context;
            _inventorReservationService = inventorReservationService;
        }
    }
}
