using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class Inventorius
    {
        public Inventorius()
        {
            InventoriausRezervacijos = new HashSet<InventoriausRezervacijos>();
        }

        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public int Kiekis { get; set; }
        public string KabinetoNumeris { get; set; }
        public int? KiekisLaisvu { get; set; }
        public string GaliojimoLaikasNuo { get; set; }
        public string GaliojimoLaikasIki { get; set; }

        public virtual ICollection<InventoriausRezervacijos> InventoriausRezervacijos { get; set; }
    }
}
