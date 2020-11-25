using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class Ataskaitos
    {
        public int Id { get; set; }
        public string RegsitracijosData { get; set; }
        public string ApsilankymuSarasa { get; set; }
        public string GyvunuIsrasai { get; set; }
        public string GyvunuIstorija { get; set; }
        public string Dokumentai { get; set; }
        public int FkKlientaiidKlientai { get; set; }

        public virtual Klientai FkKlientaiidKlientaiNavigation { get; set; }
    }
}
