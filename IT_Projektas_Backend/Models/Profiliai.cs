using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class Profiliai
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string Adresas { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AsmensKodas { get; set; }
        public string Pastas { get; set; }
        public string TelefonoNr { get; set; }
        public virtual Darbuotojai Darbuotojai { get; set; }
        public virtual Klientai Klientai { get; set; }
        public virtual ProfilioNuotraukos ProfilioNuotraukos { get; set; }
    }
}
