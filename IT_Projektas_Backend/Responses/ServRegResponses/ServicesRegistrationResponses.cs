using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.ServRegResponses
{
    public class ServicesRegistrationResponses
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string LaikasNuo { get; set; }
        public string LaikasIki { get; set; }
        public int FkPaslaugaid { get; set; }
        public int FkDarbuotojaiidDarbuotojai { get; set; }
        public int FkKlientaiidKlientai { get; set; }
    }
}
