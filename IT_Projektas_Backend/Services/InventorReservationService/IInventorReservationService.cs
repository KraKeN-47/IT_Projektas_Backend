using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.InventorReservationRequestModels;
using IT_Projektas_Backend.Responses.InventorReservationResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.InventorReservationService
{
    public interface IInventorReservationService
    {
        public Task<List<InventorReservationResponse>> GetReservations(ReservationReq req);
        InventoriausRezervacijos AddReservation(ReservationRequestModel request);
    }
}
