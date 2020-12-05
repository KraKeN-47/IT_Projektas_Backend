using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_Projektas_Backend.RequestModels.ServiRegRequestModels
{
    public class ServiRegAddRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public string LaikasNuo { get; set; }
        [Required]
        public string LaikasIki { get; set; }
        [Required]
        public int FkPaslaugaid { get; set; }
        [Required]
        public int FkDarbuotojaiidDarbuotojai { get; set; }
        [Required]
        public int FkKlientaiidKlientai { get; set; }
    }
}
