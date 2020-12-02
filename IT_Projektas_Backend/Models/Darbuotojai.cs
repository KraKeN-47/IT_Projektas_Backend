using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class Darbuotojai
    {
        public Darbuotojai()
        {
            InventoriausRezervacijos = new HashSet<InventoriausRezervacijos>();
            PaslaugosRezervacija = new HashSet<PaslaugosRezervacija>();
        }

        public string Pozicija { get; set; }
        public bool? IsAdmin { get; set; }
        public int IdDarbuotojai { get; set; }
        public int FkProfiliaiid { get; set; }

        public virtual Profiliai FkProfiliai { get; set; }
        public virtual Paslaugos Paslaugos { get; set; }
        public virtual ICollection<InventoriausRezervacijos> InventoriausRezervacijos { get; set; }
        public virtual ICollection<PaslaugosRezervacija> PaslaugosRezervacija { get; set; }
    }
}
