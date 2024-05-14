using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Pronia.Business.Exceptions;
using Pronia.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pronia.Business.Extensions
{
    public static class Helper
    {
        public static string SaveFile(string rootPath, string foulder, IFormFile file)
        {
            if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")

                throw new ImageContentTypeException("Fayl formati duzgun deyil!");
            if (file.FileName.Length > 2097152)
                throw new ImageSizeException("en cox 2 mb yer tutlamlidir!");
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            string path = rootPath + $@"\{foulder}\" + fileName;
            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;

        }
        public static void DeleteFile(string rootPath, string foulder,string filename)
        {
            string path=rootPath+ $@"\{foulder}\" + filename;
            if (!File.Exists(path)) throw new Exceptions.FileNotFoundException($"bele fayl adresinde yoxdur");
            File.Delete(path);
        }
    }
}
