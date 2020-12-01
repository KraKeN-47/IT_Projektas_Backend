using IT_Projektas_Backend.Models;
using Microsoft.EntityFrameworkCore;
using IT_Projektas_Backend.Responses.InventorResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            List<Inventorius> inventor = await _context.Inventorius.Include(x=>x.Id).ToListAsync();
            List<InventorResponse> inves = new List<InventorResponse>();
            foreach(Inventorius inv in inventor)
            {
                inves.Add(new InventorResponse
                {
                    Name = inv.Pavadinimas,
                    Amount=inv.Kiekis,
                    Room=int.Parse(inv.KabinetoNumeris),
                    Free=inv.KiekisLaisvu, 
                    GoodFrom= inv.GaliojimoLaikasNuo,
                    GoodUntil=inv.GaliojimoLaikasIki
                }) ;
            }
            return inves;
        }
    }
}
