using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class Paslaugos
    {
        public Paslaugos()
        {
            PaslaugosRezervacija = new HashSet<PaslaugosRezervacija>();
        }

        public int Id { get; set; }
        public int? Rizika { get; set; }
        public string Pavadinimas { get; set; }
        public double? Kaina { get; set; }
        public string Aprasymas { get; set; }
        public bool? Narkoze { get; set; }
        public string Trukme { get; set; }
        public int FkDarbuotojaiidDarbuotojai { get; set; }

        public virtual Darbuotojai FkDarbuotojaiidDarbuotojaiNavigation { get; set; }
        public virtual ICollection<PaslaugosRezervacija> PaslaugosRezervacija { get; set; }
    }
}
