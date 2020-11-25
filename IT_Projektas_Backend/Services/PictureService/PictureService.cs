using IT_Projektas_Backend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.PictureRequestModels
{
    public class PictureService : IPictureService
    {
        private readonly it_projektasContext _context;
        public PictureService(it_projektasContext context)
        {
            _context = context;
        }

        public ProfilioNuotraukos BuildPictureUploadProfilePictureRequest(string filePath, int fileSize, string fileFormat, string userId)
        {
            var profilioNuotrauka = new ProfilioNuotraukos
            {
                FailoDydis = fileSize,
                Formatas = fileFormat,
                Kelias = filePath,
                FkProfiliaiid = int.Parse(userId)
            };

            return profilioNuotrauka;
        }

        public async Task<FilePathAndSize> UploadPictureAsync(PictureUploadRequest request, string pictureFormat)
        {
            // path to store profile picture
            var solutionRootPath = Path.GetFullPath("./ProfilePictureStorage");
            // rename profile picture to userId and write the picture into the storage
            var filePath = Path.Combine(solutionRootPath, $"{request.UserId}.{pictureFormat}");
            using (var fs = new FileStream(filePath, FileMode.Create))
            {
                await request.File.CopyToAsync(fs);
            }

            double size = new FileInfo(filePath).Length;
            size /= 1024; // get size in kb
            int fileSize = (int)Math.Ceiling(size);
            return new FilePathAndSize(fileSize, filePath);
        }
    }
}
