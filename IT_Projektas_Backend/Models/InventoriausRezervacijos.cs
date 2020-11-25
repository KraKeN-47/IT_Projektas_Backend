using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class InventoriausRezervacijos
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string LaikasNuo { get; set; }
        public string LaikasIki { get; set; }
        public int FkDarbuotojaiidDarbuotojai { get; set; }
        public int FkInventoriusid { get; set; }

        public virtual Darbuotojai FkDarbuotojaiidDarbuotojaiNavigation { get; set; }
        public virtual Inventorius FkInventorius { get; set; }
    }
}
