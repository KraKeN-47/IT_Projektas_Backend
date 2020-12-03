using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.AuthRequestModels
{
    public class AuthChangeEmailRequest
    {
        public string userId { get; set; }
        public string email { get; set; }
    }
}
