using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses
{
    public class AuthLoginResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
