using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.ReportsResponses
{
    public class WorkerWithReport
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string Adresas { get; set; }
        public string Pastas { get; set; }
        public string AsmensKodas { get; set; }
        public string TelefonoNr { get; set; }
        public string Pozicija { get; set; }
        public bool? isAdmin { get; set; }

        public PersonalResponse Report{ get; set; }

    }
}
