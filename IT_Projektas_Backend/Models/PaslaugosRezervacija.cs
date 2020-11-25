using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class PaslaugosRezervacija
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string LaikasNuo { get; set; }
        public string LaikasIki { get; set; }
        public int FkPaslaugaid { get; set; }
        public int FkDarbuotojaiidDarbuotojai { get; set; }
        public int FkKlientaiidKlientai { get; set; }

        public virtual Darbuotojai FkDarbuotojaiidDarbuotojaiNavigation { get; set; }
        public virtual Klientai FkKlientaiidKlientaiNavigation { get; set; }
        public virtual Paslaugos FkPaslauga { get; set; }
    }
}
