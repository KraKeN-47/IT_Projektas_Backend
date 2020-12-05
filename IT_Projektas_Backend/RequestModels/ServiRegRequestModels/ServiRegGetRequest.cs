using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.ServiRegRequestModels
{
    public class ServiRegGetRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
