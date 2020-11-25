using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.PictureRequestModels
{
    public class PictureDeleteRequest
    {
        [Required]
        public string UserId { get; set; }
    }
}
