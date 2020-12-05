using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_Projektas_Backend.RequestModels.ServiRequestModels
{
    public class ServiAddRequest
    {
        [Required]
        public int? Rizika { get; set; }
        [Required]
        public string Pavadinimas { get; set; }
        [Required]
        public double? Kaina { get; set; }
        [Required]
        public string Aprasymas { get; set; }
        [Required]
        public bool? Narkoze { get; set; }
        [Required]
        public string Trukme { get; set; }
        [Required]
        public int FkDarbuotojaiidDarbuotojai { get; set; }
    }
}
