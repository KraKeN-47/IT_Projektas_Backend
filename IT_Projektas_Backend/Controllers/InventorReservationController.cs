using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.InventorRequestModels;
using IT_Projektas_Backend.RequestModels.InventorReservationRequestModels;
using IT_Projektas_Backend.RequestModels.PictureRequestModels;
using IT_Projektas_Backend.Responses.InventorResponses;
using IT_Projektas_Backend.Services.InventorReservationService;
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
        private readonly IInventorReservationService _inventorReservationService;
        public InventorReservationController(it_projektasContext context, IInventorReservationService inventorReservationService)
        {
            _context = context;
            _inventorReservationService = inventorReservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReservations(int profileID)
        {
            ReservationReq req = new ReservationReq { DarbuotojoID = profileID };
            var obj = _inventorReservationService.GetReservations(req);

            return Ok(obj);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReservation (ReservationDeleteReq req)
        {            
            int id = req.ID;
            var reservation = await _context.InventoriausRezervacijos.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.InventoriausRezervacijos.Remove(reservation);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public IActionResult AddReservation (ReservationRequestModel request)
        {
            var obj = _inventorReservationService.AddReservation(request);
            return Ok();
        }

    }
}
