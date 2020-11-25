using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class Klientai
    {
        public Klientai()
        {
            Gyvunai = new HashSet<Gyvunai>();
            PaslaugosRezervacija = new HashSet<PaslaugosRezervacija>();
        }

        public int GyvunuKiekis { get; set; }
        public int IdKlientai { get; set; }
        public int FkProfiliaiid { get; set; }

        public virtual Profiliai FkProfiliai { get; set; }
        public virtual Ataskaitos Ataskaitos { get; set; }
        public virtual ICollection<Gyvunai> Gyvunai { get; set; }
        public virtual ICollection<PaslaugosRezervacija> PaslaugosRezervacija { get; set; }
    }
}
