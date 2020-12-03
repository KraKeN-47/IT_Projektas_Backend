using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.Responses.InventorResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.InventorReservationResponses
{
    public class InventorReservationResponse
    {
        public string Data { get; set; }
        public string LaikasNuo { get; set; }
        public string LaikasIki { get; set; }
        public int FkDarbuotojaiidDarbuotojai { get; set; }

        public InventorResponse inventorius { get; set; }
    }
}
