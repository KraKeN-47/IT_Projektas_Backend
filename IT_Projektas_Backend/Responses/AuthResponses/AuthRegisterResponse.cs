using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses
{
    public class AuthRegisterResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
