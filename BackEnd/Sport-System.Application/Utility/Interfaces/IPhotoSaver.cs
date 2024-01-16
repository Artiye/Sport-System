using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_System.Application.Utility.Interfaces
{
    public interface IPhotoSaver
    {
        Task<string> SavePhoto(IFormFile photoFile);
    }
}