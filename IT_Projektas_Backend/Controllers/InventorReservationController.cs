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

        [HttpGet("getAllInventorReservations/{id}")]
        public async Task<IActionResult> GetReservations(string id)
        {
            int profileID = int.Parse(id);
            ReservationReq req = new ReservationReq { DarbuotojoID = profileID };
            var obj = await _inventorReservationService.GetReservations(req);

            return Ok(obj);
        }

        [HttpDelete("CancelReservation/{userId}")]
        public async Task<IActionResult> CancelReservation (string userId)
        {
            int id = int.Parse(userId);
            var reservation = await _context.InventoriausRezervacijos.Where(x => x.Id == id).FirstOrDefaultAsync();
            _context.InventoriausRezervacijos.Remove(reservation);
            var tempReserv = _context.Inventorius.Where(x => x.Id == reservation.FkInventoriusid).FirstOrDefault();
            int amount = (int)(tempReserv.KiekisLaisvu);
            tempReserv.KiekisLaisvu = amount + 1;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("AddReservation")]
        public IActionResult AddReservation ([FromBody]ReservationRequestModel request)
        {
            var obj = _inventorReservationService.AddReservation(request);
            var tempReserv = _context.Inventorius.Where(x => x.Id == request.Inventoriusid).FirstOrDefault();
            int amount = (int)(tempReserv.KiekisLaisvu);
            tempReserv.KiekisLaisvu = amount - 1;
            _context.SaveChanges();
            return Ok();
        }

    }
}
