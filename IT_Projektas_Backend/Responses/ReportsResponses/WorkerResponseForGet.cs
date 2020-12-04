using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.ReportsResponses
{
    public class WorkerResponseForGet
    {
        public string Pozicija { get; set; }
        public bool IsAdmin { get; set; }
        public int IdDarbuotojai { get; set; }
        public int FkProfiliaiid { get; set; }
    }
}
