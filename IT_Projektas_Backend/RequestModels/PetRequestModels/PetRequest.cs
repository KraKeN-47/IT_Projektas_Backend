using IT_Projektas_Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.AnimalRequestModels
{
    public class PetRequest
    {
        [Required]
        public string Rusis { get; set; }
        [Required]
        public string Vardas { get; set; }
        [Required]
        public string Veisle { get; set; }
        [Required]
        public int? Amzius { get; set; }
        [Required]
        public double? Svoris { get; set; }
        [Required]
        public int? Lytis { get; set; }
        [Required]
        public int FkKlientaiidKlientai { get; set; }
        public PetRequest() { }
        public PetRequest(string rusis, string vardas, string veisle, int amzius, double svoris, int lytis, int klientai)
        {
            Rusis = rusis;
            Vardas = vardas;
            Veisle = veisle;
            Amzius = amzius;
            Svoris = svoris;
            Lytis = lytis;
            FkKlientaiidKlientai = klientai;
        }
        public PetRequest(Gyvunai gyv)
        {
            Rusis = gyv.Rusis;
            Vardas = gyv.Vardas;
            Veisle = gyv.Veisle;
            Amzius = gyv.Amzius;
            Svoris = gyv.Svoris;
            Lytis = gyv.Lytis;
            FkKlientaiidKlientai = gyv.FkKlientaiidKlientai;
        }
    }
}
