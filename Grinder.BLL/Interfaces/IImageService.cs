using Grinder.BLL.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IImageService
    {
        Task UploadImages(IHostingEnvironment _appEnvironment, IFormFile[] images, string user);
        Task UploadProfilePicture(IHostingEnvironment _appEnvironment, IFormFile image, string user);
        Task DeleteImage(int id, IHostingEnvironment _appEnvironment);
        Task DeleteProfilePicture(int id, IHostingEnvironment _appEnvironment);
        Task UpdateProfilePicture(IHostingEnvironment _appEnviroment, IFormFile newImage, ThumbnailDTO oldImage, string user);
    }
}
