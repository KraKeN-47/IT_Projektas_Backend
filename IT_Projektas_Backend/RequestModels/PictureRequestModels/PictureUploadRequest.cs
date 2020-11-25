using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.PictureRequestModels
{
    public class PictureUploadRequest
    {
        public IFormFile File { get; set; }
        public string UserId { get; set; }
    }
}
