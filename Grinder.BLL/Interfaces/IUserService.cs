using Grinder.BLL.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IUserService
    {
        Task UploadImages(IHostingEnvironment _appEnvironment, IFormFile[] images, UserDTO user);
        Task UploadProfilePicture(IHostingEnvironment _appEnvironment, IFormFile image, UserDTO user);
        Task UpdateProfile(UserDTO user);
    }
}
