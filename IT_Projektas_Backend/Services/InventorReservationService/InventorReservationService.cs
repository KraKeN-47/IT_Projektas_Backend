using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.InventorRequestModels;
using IT_Projektas_Backend.RequestModels.InventorReservationRequestModels;
using IT_Projektas_Backend.Responses.InventorReservationResponses;
using IT_Projektas_Backend.Responses.InventorResponses;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<InventorReservationResponse>> GetReservations(ReservationReq req) 
        {
            int tempID = _context.Darbuotojai.Where(x => x.FkProfiliaiid == req.DarbuotojoID).First().IdDarbuotojai;
            List<InventoriausRezervacijos> reserved = await _context.InventoriausRezervacijos.Where(x => x.FkDarbuotojaiidDarbuotojai == tempID).ToListAsync();
            List<InventorReservationResponse> responses = new List<InventorReservationResponse>();
            foreach(var res in reserved)
            {
                string temp = _context.Inventorius.Where(x => x.Id == res.FkInventoriusid).FirstOrDefault().Pavadinimas;
                responses.Add(new InventorReservationResponse
                {
                    ID=res.Id,
                    Data = res.Data,
                    LaikasNuo=res.LaikasNuo,
                    LaikasIki=res.LaikasIki,
                    FkDarbuotojaiidDarbuotojai=res.FkDarbuotojaiidDarbuotojai,
                    inventorius=temp
                });                
            }

            return responses;
        }

        public InventoriausRezervacijos AddReservation (ReservationRequestModel request)
        {
            int tempDarbuotojoID = _context.Darbuotojai.Where(x => x.FkProfiliaiid == request.ProfilioID).FirstOrDefault().IdDarbuotojai;
            InventoriausRezervacijos addThis = new InventoriausRezervacijos
            {
                Data=request.Data,
                LaikasNuo=request.LaikasNuo,
                LaikasIki=request.LaikasIki,
                FkDarbuotojaiidDarbuotojai=tempDarbuotojoID,
                FkInventoriusid=request.Inventoriusid
            };

            _context.InventoriausRezervacijos.Add(addThis);
            _context.SaveChanges();
            return addThis;
        }


    }
}
