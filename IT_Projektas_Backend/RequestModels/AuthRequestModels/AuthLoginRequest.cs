using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels
{
    public class AuthLoginRequest
    {
        [Required]
        public string Password { get; set; }
        [Required]
        public string Pastas { get; set; }
    }
}
