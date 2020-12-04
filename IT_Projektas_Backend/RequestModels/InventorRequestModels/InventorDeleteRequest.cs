using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.InventorRequestModels
{
    public class InventorDeleteRequest
    {
        [Required]
        public int ID { get; set; }
    }
}
