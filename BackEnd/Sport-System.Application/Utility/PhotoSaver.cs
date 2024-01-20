using Microsoft.AspNetCore.Http;
using Sport_System.Application.Utility.Interfaces;
using Sport_System.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Utility
{
    public class PhotoSaver : IPhotoSaver
    {
        public PhotoSaver() { }

        public async Task<string> SavePhoto(IFormFile photoFile)
        {
            if (photoFile == null || photoFile.Length == 0)
                throw new ArgumentException("Invalid photo file.");

            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);
            string filePath = Path.Combine("../../FrontEnd/public/images/", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await photoFile.CopyToAsync(stream);
            }
            return "/images/" + fileName;
        }
    }
}
