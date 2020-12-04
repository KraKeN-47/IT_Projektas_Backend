using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.ServResponses
{
    public class ServicesResponses
    {
        public int Id { get; set; }
        public int? Rizika { get; set; }
        public string Pavadinimas { get; set; }
        public double? Kaina { get; set; }
        public string Aprasymas { get; set; }
        public bool? Narkoze { get; set; }
        public string Trukme { get; set; }
    }
}
