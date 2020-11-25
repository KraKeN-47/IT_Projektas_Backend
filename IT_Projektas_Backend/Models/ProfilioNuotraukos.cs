using System;
using System.Collections.Generic;

namespace IT_Projektas_Backend.Models
{
    public partial class ProfilioNuotraukos
    {
        public int Id { get; set; }
        public string Kelias { get; set; }
        public int? FailoDydis { get; set; }
        public string Formatas { get; set; }
        public int? FkProfiliaiid { get; set; }

        public virtual Profiliai FkProfiliai { get; set; }
    }
}
