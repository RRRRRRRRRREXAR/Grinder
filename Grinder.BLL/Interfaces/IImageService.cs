using Grinder.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IImageService
    {
        Task UploadImages(IEnumerable<ImageDTO> images);
        Task UploadProfileImage(ImageDTO image);
        Task DeleteImage(int id);
    }
}
