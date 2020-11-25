using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Services.AuthService
{
    public class JwtSettings
    {
        public string secretKey { get; set; }
        public JwtSettings()
        {
            GetConfiguration conf = new GetConfiguration();
            this.secretKey = conf.GetConfig().GetSection("JwtSettings").GetSection("Secret").Value;
        }
    }
}
