using IT_Projektas_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.PictureRequestModels
{
    public interface IPictureService
    {
        ProfilioNuotraukos BuildPictureUploadProfilePictureRequest(string filePath, int fileSize, string fileFormat, string userId );
        Task<FilePathAndSize> UploadPictureAsync(PictureUploadRequest request, string pictureFormat);
    }
}
