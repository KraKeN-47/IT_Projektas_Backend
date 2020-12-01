using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.Responses.InventorResponses
{
    public class InventorResponse
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Room { get; set; }
        public int? Free { get; set; }
        public string GoodFrom { get; set; }
        public string GoodUntil { get; set; }

    }
}
