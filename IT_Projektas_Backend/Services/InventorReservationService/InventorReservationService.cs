using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.Responses.InventorReservationResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.InventorReservationService
{
    public class InventorReservationService:IInventorReservationService
    {

        private readonly it_projektasContext _context;
        public InventorReservationService(it_projektasContext context)
        {
            _context = context;
        }
        public Task<List<InventorReservationResponse>> GetReservations() 
        {
            
        }
    }
}
