using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.AuthResponses
{
    public class AuthMyPetsResponse
    {
        public int Id { get; set; }
        public string Rusis { get; set; }
        public string Vardas { get; set; }
        public string Veisle { get; set; }
        public int? Amzius { get; set; }
        public double? Svoris { get; set; }
        public int? Lytis { get; set; }

    }
}
