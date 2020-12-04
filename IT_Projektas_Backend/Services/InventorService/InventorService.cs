using IT_Projektas_Backend.Models;
using Microsoft.EntityFrameworkCore;
using IT_Projektas_Backend.Responses.InventorResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.RequestModels.InventorRequestModels;

namespace IT_Projektas_Backend.Services.InventorService
{
    public class InventorService : IInventorService
    {
        private readonly it_projektasContext _context;
        public InventorService(it_projektasContext context)
        {
            _context = context;
        }
        public async Task<List<InventorResponse>> GetInventor()
        {
            List<Inventorius> inventor = await _context.Inventorius.OrderBy(x => x.Pavadinimas).ToListAsync();
            List<InventorResponse> inves = new List<InventorResponse>();
            foreach(Inventorius inv in inventor)
            {
                inves.Add(new InventorResponse
                {
                    ID=inv.Id,
                    Name = inv.Pavadinimas,
                    Amount=inv.Kiekis,
                    Room=inv.KabinetoNumeris,
                    Free=inv.KiekisLaisvu, 
                    GoodFrom= inv.GaliojimoLaikasNuo,
                    GoodUntil=inv.GaliojimoLaikasIki
                }) ;
            }
            return inves;
        }

        public Inventorius AddInventor(InventorReq request)
        {
            var inventor = new Inventorius
            {
                Pavadinimas = request.Name,
                Kiekis = request.Amount,
                KabinetoNumeris = request.Room,
                KiekisLaisvu = request.Free,
                GaliojimoLaikasNuo = request.GoodFrom,
                GaliojimoLaikasIki = request.GoodUntil
            };
            _context.Inventorius.Add(inventor);
            _context.SaveChanges();
            return inventor;
        }
    }
}
