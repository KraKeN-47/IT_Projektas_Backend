﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.InventorRequestModels
{
    public class InventorReq
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public string Room { get; set; }
        [Required]
        public int? Free { get; set; }
        [Required]
        public string GoodFrom { get; set; }
        [Required]
        public string GoodUntil { get; set; }
    }
}
