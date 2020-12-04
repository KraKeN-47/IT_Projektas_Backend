using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using IT_Projektas_Backend.Responses.PetResponses;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.AnimalService
{
    public class PetService : IPetService
    {
        it_projektasContext _context;

        public PetService(it_projektasContext context)
        {
            _context = context;
        }

        public Gyvunai AddPet(PetRequest request)
        {
            int klientoId = _context.Klientai.Where(x => x.FkProfiliaiid == request.FkKlientaiidKlientai).Select(x => x.IdKlientai).FirstOrDefault();
            var pet = new Gyvunai
            {
                Amzius = request.Amzius,
                Lytis = request.Lytis,
                Rusis = request.Rusis,
                Svoris = request.Svoris,
                Vardas = request.Vardas,
                Veisle = request.Veisle,
                FkKlientaiidKlientai = klientoId,
            };
            _context.Gyvunai.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        public async Task<List<PetRetrieveResponse>> GetPets()
        {
            var pets = await _context.Gyvunai.ToListAsync();
            List<PetRetrieveResponse> list = new List<PetRetrieveResponse>();
            foreach (Gyvunai pet in pets)
            {
                list.Add(new PetRetrieveResponse(pet));
            }
            return list;
        }

        public async Task<List<PetRetrieveResponse>> GetUserPets(int profileid)
        {
            int id = await _context.Klientai.Where(x => x.FkProfiliaiid == profileid).Select(x => x.IdKlientai).FirstOrDefaultAsync();
            List<Gyvunai> gyvunai = await _context.Gyvunai.Where(gyv => gyv.FkKlientaiidKlientai == id).ToListAsync();
            List<PetRetrieveResponse> pets = new List<PetRetrieveResponse>();
            foreach (Gyvunai gyvunas in gyvunai)
            {
                pets.Add(new PetRetrieveResponse(gyvunas));
            }
            return pets;
        }

        public void RemovePet(int id)
        {
            var pet = _context.Gyvunai.Where(x => x.Id == id).FirstOrDefault();
            if (pet == null)
            {
                throw new RowNotInTableException("Pet with id " + id + " does not exist");
            }
            _context.Remove(pet);
            _context.SaveChanges();
        }
    }
}
