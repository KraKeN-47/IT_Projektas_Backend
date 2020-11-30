using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using IT_Projektas_Backend.Responses.ClientRsponses;
using IT_Projektas_Backend.Responses.PetResponses;
using IT_Projektas_Backend.Services.AnimalService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly it_projektasContext _context;
        public ClientService(it_projektasContext context)
        {
            _context = context;
        }

        public async Task<List<ClientRetrieveResponse>> GetClients()
        {
            List<Klientai> clients = await _context.Klientai.Include(x => x.FkProfiliai).ToListAsync();
            List<ClientRetrieveResponse> clientsList = new List<ClientRetrieveResponse>();
            foreach(Klientai cl in clients)
            {
                ICollection<PetRetrieveResponse> pets = GetPets(cl.IdKlientai).Result;
                clientsList.Add(new ClientRetrieveResponse
                {
                    Adresas = cl.FkProfiliai.Adresas,
                    Pastas = cl.FkProfiliai.Pastas,
                    Pavarde = cl.FkProfiliai.Pavarde,
                    Vardas = cl.FkProfiliai.Vardas,
                    TelefonoNr = cl.FkProfiliai.TelefonoNr,
                    Pets = pets
                });
            }
            return clientsList;
        }

        public async Task<List<PetRetrieveResponse>> GetPets(int id)
        {
            List<Gyvunai> gyvunai = await _context.Gyvunai.Where(gyv => gyv.FkKlientaiidKlientai == id).ToListAsync();
            List<PetRetrieveResponse> pets = new List<PetRetrieveResponse>();
            foreach(Gyvunai gyvunas in gyvunai)
            {
                pets.Add(new PetRetrieveResponse(gyvunas));
            }
            return pets;
        }
    }
}
