using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.PictureRequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Projektas_Backend.Controllers
{
    public class PictureController : ControllerBase
    {
        private readonly it_projektasContext _context;
        private readonly IPictureService _pictureService;

        public PictureController(it_projektasContext context, IPictureService pictureService)
        {
            _context = context;
            _pictureService = pictureService;
        }

        [HttpPost("api/[controller]/upload")]
        public async Task<IActionResult> UploadPicture(PictureUploadRequest request)
        {
            var fileFormat = request.File.ContentType;
            if (request == null || (!fileFormat.Equals("image/jpeg") && !fileFormat.Equals("image/png")))
            {
                return BadRequest("Neteisingas failo formatas");
            }
            var pictureFormat = fileFormat.Equals("image/jpeg") ? "jpg" : "png";
            var obj = await _pictureService.UploadPictureAsync(request, pictureFormat);
            var profilePicture = _pictureService.BuildPictureUploadProfilePictureRequest(obj.FilePath, obj.FileSize, pictureFormat, request.UserId);
            await _context.ProfilioNuotraukos.AddAsync(profilePicture);
            await _context.SaveChangesAsync();

            return Ok();
        }
        [HttpDelete("api/[controller]/delete")]
        public async Task<IActionResult> DeletePicture(PictureDeleteRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request payload is null");
            }
            int userId = int.Parse(request.UserId);
            var profilioNuotrauka = await _context.ProfilioNuotraukos.Where(entity => entity.FkProfiliaiid == userId).FirstOrDefaultAsync();
            _context.ProfilioNuotraukos.Remove(profilioNuotrauka);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
