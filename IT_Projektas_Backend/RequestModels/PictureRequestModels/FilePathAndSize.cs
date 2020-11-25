using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IT_Projektas_Backend.RequestModels.PictureRequestModels
{
    public class FilePathAndSize
    {
        public int FileSize { get; set; }
        public string FilePath { get; set; }
        public FilePathAndSize(int fileSize, string filePath)
        {
            FileSize = fileSize;
            FilePath = filePath;
        }
    }
}
