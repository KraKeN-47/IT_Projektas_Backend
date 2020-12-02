using IT_Projektas_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.InventorReservationResponses
{
    public class InventorReservationResponse
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public string LaikasNuo { get; set; }
        public string LaikasIki { get; set; }
        public int FkDarbuotojaiidDarbuotojai { get; set; }
        public int FkInventoriusid { get; set; }

        public virtual Darbuotojai FkDarbuotojaiidDarbuotojaiNavigation { get; set; }
        public virtual Inventorius FkInventorius { get; set; }
    }
}
