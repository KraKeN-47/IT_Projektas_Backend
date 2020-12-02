using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.AnimalRequestModels;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
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
            var pet = new Gyvunai
            {
                Amzius = request.Amzius,
                Lytis = request.Lytis,
                Rusis = request.Rusis,
                Svoris = request.Svoris,
                Vardas = request.Vardas,
                Veisle = request.Veisle,
                FkKlientaiidKlientai = request.FkKlientaiidKlientai,
            };
            _context.Gyvunai.Add(pet);
            _context.SaveChanges();
            return pet;
        }
    }
}
