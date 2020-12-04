using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.Responses.ReportsResponses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.ReportsService
{
    public class ReportsService:IReportsService

    {
        private readonly it_projektasContext _context;
        public ReportsService(it_projektasContext context)
        {
            _context = context;
        }

        public async Task<List<PositionsResponse>> PositionsReport()
        {
            List<Darbuotojai> employees = await _context.Darbuotojai.ToListAsync();
            List<PositionsResponse> positions = new List<PositionsResponse>();
            foreach(var empl in employees)
            {
                int n = 0;
                foreach(var position in positions)
                {
                    if (position.PositionName.CompareTo(empl.Pozicija)==0)
                    {
                        position.Amount++;
                        break;
                    }
                    else n++;
                }

                if(n==positions.Count())
                {
                    positions.Add(new PositionsResponse { PositionName = empl.Pozicija, Amount = 1 });
                }
            }

            return positions;
        }


        public async Task<PersonalResponse> PersonalReport(int profileID)
        {
            int tempID = _context.Darbuotojai.Where(x => x.FkProfiliaiid == profileID).First().IdDarbuotojai;
            List<PaslaugosRezervacija> paslaugos = await _context.PaslaugosRezervacija.Where(x => x.FkDarbuotojaiidDarbuotojai == tempID).ToListAsync();
            int res = (from x in paslaugos select x.FkKlientaiidKlientai).Distinct().Count();
            PersonalResponse response = new PersonalResponse { AmountOfRezervations=paslaugos.Count(), AmountOfClients=res};

            return response;
        }

        public async Task<List<WorkerResponseForGet>> GetWorkers()
        {
            List<Darbuotojai> workers = await _context.Darbuotojai.OrderBy(x => x.Pozicija).ToListAsync();
            List<WorkerResponseForGet> wrkrs = new List<WorkerResponseForGet>();
            foreach (var wrkr in workers)
            {
                wrkrs.Add(new WorkerResponseForGet
                {
                    Pozicija=wrkr.Pozicija,
                    IsAdmin=(bool)(wrkr.IsAdmin),
                    IdDarbuotojai=wrkr.IdDarbuotojai,
                    FkProfiliaiid=wrkr.FkProfiliaiid
                });
            }
            return wrkrs;
        }

    }
}
