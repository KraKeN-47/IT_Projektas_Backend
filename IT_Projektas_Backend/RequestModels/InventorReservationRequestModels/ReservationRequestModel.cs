using IT_Projektas_Backend.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.InventorReservationRequestModels
{
    public class ReservationRequestModel
    {

        [Required]
        public int Id { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        public string LaikasNuo { get; set; }
        [Required]
        public string LaikasIki { get; set; }
        [Required]
        public int FkDarbuotojaiidDarbuotojai { get; set; }
        [Required]
        public int FkInventoriusid { get; set; }
        [Required]
        public virtual Darbuotojai FkDarbuotojaiidDarbuotojaiNavigation { get; set; }
        [Required]
        public virtual Inventorius FkInventorius { get; set; }
    }
}
