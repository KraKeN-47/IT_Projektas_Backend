using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.PictureRequestModels
{
    public class PictureUploadRequest
    {
        [FromForm(Name = "image")]
        public IFormFile File { get; set; }
        public string UserId { get; set; }
    }
}
