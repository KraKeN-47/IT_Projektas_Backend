using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using IT_Projektas_Backend.Responses.ServResponses;
using IT_Projektas_Backend.RequestModels.ServiRequestModels;
using System.Text;

namespace IT_Projektas_Backend.Services.ServiService
{
    public class ServicesService : IServicesService
    {
        private readonly it_projektasContext _context;

        public ServicesService(it_projektasContext context)
        {
            _context = context;
        }
        public async Task<List<ServicesResponses>> BuildServicesGetRequest()
        {
            List<Paslaugos> service = await _context.Paslaugos.OrderBy(x => x.Pavadinimas).ToListAsync();
            List<PaslaugosRezervacija> reqServices = await _context.PaslaugosRezervacija.ToListAsync();
            var filteredServices = new List<Paslaugos>();
            filteredServices = service;
            if (reqServices.Count > 0)
            {
                foreach (var reqService in reqServices)
                {
                        var serviceToRemove = _context.Paslaugos.SingleOrDefault(x => x.Id == reqService.FkPaslaugaid);
                    filteredServices.Remove(serviceToRemove);
                }
            }
            else
            {
                filteredServices = service;
            }

            List<ServicesResponses> servs = new List<ServicesResponses>();
            foreach (Paslaugos ser in filteredServices)
            {
                var profileId =  _context.Darbuotojai.SingleOrDefault(e => e.IdDarbuotojai == ser.FkDarbuotojaiidDarbuotojai).FkProfiliaiid;
                var profile = _context.Profiliai.SingleOrDefault(e => e.Id == profileId);

                var vardasPav = $"{profile.Vardas} {profile.Pavarde}";

                servs.Add(new ServicesResponses
                {
                    Id=ser.Id,
                    Rizika = ser.Rizika,
                    Pavadinimas = ser.Pavadinimas,
                    Kaina = ser.Kaina,
                    Aprasymas = ser.Aprasymas,
                    Narkoze = ser.Narkoze,
                    Trukme = ser.Trukme,
                    DarbutojoVarPav = vardasPav,
                    FkDarbuotojaiidDarbuotojai = ser.FkDarbuotojaiidDarbuotojai
                });
            }
            return servs;
        }
        public Paslaugos BuildServicesAddRequest(ServiAddRequest request)
        {
            var service = new Paslaugos
            {
                Rizika = request.Rizika,
                Pavadinimas = request.Pavadinimas,
                Kaina = request.Kaina,
                Aprasymas = request.Aprasymas,
                Narkoze = request.Narkoze,
                Trukme = request.Trukme,
                FkDarbuotojaiidDarbuotojai = request.FkDarbuotojaiidDarbuotojai
            };
            _context.Paslaugos.Add(service);
            _context.SaveChanges();
            return service;
        }
    }
}
