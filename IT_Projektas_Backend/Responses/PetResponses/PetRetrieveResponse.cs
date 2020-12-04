using IT_Projektas_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.PetResponses
{
    public class PetRetrieveResponse
    {
        public int Id { get; set; }
        public string Rusis { get; set; }
        public string Vardas { get; set; }
        public string Veisle { get; set; }
        public int? Amzius { get; set; }
        public double? Svoris { get; set; }
        public int? Lytis { get; set; }
        public PetRetrieveResponse(Gyvunai gyv)
        {
            Id = gyv.Id;
            Rusis = gyv.Rusis;
            Vardas = gyv.Vardas;
            Veisle = gyv.Veisle;
            Amzius = gyv.Amzius;
            Svoris = gyv.Svoris;
            Lytis = gyv.Lytis;
        }
    }
}
