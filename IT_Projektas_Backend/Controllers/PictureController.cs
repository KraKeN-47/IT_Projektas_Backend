using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IT_Projektas_Backend.Models;
using IT_Projektas_Backend.RequestModels.PictureRequestModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Projektas_Backend.Controllers
{
    public class PictureController : ControllerBase
    {
        private readonly it_projektasContext _context;
        private readonly IPictureService _pictureService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PictureController(it_projektasContext context, IPictureService pictureService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _pictureService = pictureService;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost("api/[controller]/upload")]
        public async Task<IActionResult> UploadPicture(PictureUploadRequest request)
        {
            var fileFormat = request.File.ContentType;
            if (request == null || (!fileFormat.Equals("image/jpeg") && !fileFormat.Equals("image/png")))
            {
                return BadRequest("Neteisingas failo formatas");
            }
            if (_context.ProfilioNuotraukos.Any(e=> e.FkProfiliaiid == int.Parse(request.UserId)))
            {
                var profilePictoreToRemove = await _context.ProfilioNuotraukos.Where(e => e.FkProfiliaiid == int.Parse(request.UserId)).FirstOrDefaultAsync();
                _context.ProfilioNuotraukos.Remove(profilePictoreToRemove);
            }

            var pictureFormat = fileFormat.Equals("image/jpeg") ? "jpg" : "png";
            var obj = await _pictureService.UploadPictureAsync(request, pictureFormat);
            var profilePicture = _pictureService.BuildPictureUploadProfilePictureRequest(obj.FilePath, obj.FileSize, pictureFormat, request.UserId);
            await _context.ProfilioNuotraukos.AddAsync(profilePicture);
            await _context.SaveChangesAsync();

            var picture = await _context.ProfilioNuotraukos.Where((e) => e.FkProfiliaiid == int.Parse(request.UserId)).FirstOrDefaultAsync();
            var hostUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            hostUrl ="https://"+hostUrl+$"/profilepicturestorage/{request.UserId}.jpg";
            return Ok(new { imagePath = hostUrl});
        }
        [HttpDelete("api/[controller]/delete/{id}")]
        public async Task<IActionResult> DeletePicture(string id)
        {
            if (id == null)
            {
                return BadRequest("Serverio klaida.");
            }
            int userId = int.Parse(id);
            var profilioNuotrauka = await _context.ProfilioNuotraukos.Where(entity => entity.FkProfiliaiid == userId).FirstOrDefaultAsync();
            var filePath = profilioNuotrauka.Kelias;
            _context.ProfilioNuotraukos.Remove(profilioNuotrauka);
            await _context.SaveChangesAsync();
            System.IO.File.Delete(filePath);

            return Ok(new { message="Nuotrauka sėkmingai pašalinta" });
        }
    }
}
