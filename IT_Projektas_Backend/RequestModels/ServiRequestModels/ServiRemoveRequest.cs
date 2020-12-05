using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace IT_Projektas_Backend.RequestModels.ServiRequestModels
{
    public class ServiRemoveRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
