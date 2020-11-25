using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels
{
    public class AuthRegisterUserRequest
    {
        [Required]
        public string Vardas { get; set; }
        [Required]
        public string Pavarde { get; set; }
        [Required]
        public string Adresas { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string AsmensKodas { get; set; }
        [Required]
        public string Pastas { get; set; }
        [Required]
        public string TelefonoNr { get; set; }
    }
}
