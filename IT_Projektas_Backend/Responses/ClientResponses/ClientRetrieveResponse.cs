using IT_Projektas_Backend.Responses.PetResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.ClientRsponses
{
    public class ClientRetrieveResponse
    {
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string Adresas { get; set; }
        public string Pastas { get; set; }
        public string TelefonoNr { get; set; }
        public ICollection<PetRetrieveResponse> Pets { get; set; }
    }
}
