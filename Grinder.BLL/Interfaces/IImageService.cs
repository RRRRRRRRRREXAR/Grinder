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
        Task<IEnumerable<ImageDTO>> GetImages(UserDTO user);
        Task UploadImage(string _appEnvironment, IFormFile image, string user);
        Task UploadProfilePicture(string _appEnvironment, IFormFile image, string user);
        Task DeleteImage(int id, string _appEnvironment);
        Task DeleteProfilePicture(int id, string _appEnvironment);
        Task UpdateProfilePicture(string _appEnviroment, IFormFile newImage, ThumbnailDTO oldImage, string user);
    }
}
