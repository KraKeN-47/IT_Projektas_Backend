using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class Gyvunai
    {
        public int Id { get; set; }
        public string Rusis { get; set; }
        public string Vardas { get; set; }
        public string Veisle { get; set; }
        public int? Amzius { get; set; }
        public double? Svoris { get; set; }
        public int? Lytis { get; set; }
        public int FkKlientaiidKlientai { get; set; }

        public virtual Klientai FkKlientaiidKlientaiNavigation { get; set; }
    }
}
