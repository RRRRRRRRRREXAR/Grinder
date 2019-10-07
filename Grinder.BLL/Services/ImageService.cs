using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using Grinder.BLL.MapProfile;
using Grinder.DAL.Entities;
using Grinder.DAL.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Services
{
    public class ImageService:IImageService
    {
        readonly IUnitOfWork unit;
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
        });
        public ImageService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

        public async Task DeleteImage(int id, IHostingEnvironment _appEnvironment)
        {
           Image image= await unit.Images.Get(id);
            var imgName = image.Link.Split('/')[4];
            await unit.Images.Delete(id);
            File.Delete(_appEnvironment.WebRootPath + "\\Images\\" + imgName);
           unit.Save();
        }

        public async Task DeleteProfilePicture(int id, IHostingEnvironment _appEnvironment)
        {
            Thumbnail profilePic = await unit.Thumbnails.Get(id);
            var imgName = profilePic.Link.Split('/')[4];
            await unit.Thumbnails.Delete(id);
            File.Delete(_appEnvironment.WebRootPath + "\\Images\\" + imgName);
            unit.Save();
        }

        public async Task UpdateProfilePicture(IHostingEnvironment _appEnviroment, IFormFile newImage, ThumbnailDTO oldImage)
        {
            var mapper = new Mapper(config);
            var imgName = oldImage.Link.Split('/')[4];
            File.Delete(_appEnviroment.WebRootPath + "\\Images\\" + imgName);
            var fileName = ContentDispositionHeaderValue.Parse(newImage.ContentDisposition).FileName.Trim('"');
            string path = "/Images/" + fileName;
            using (var fileStream = new FileStream(_appEnviroment.WebRootPath + path, FileMode.Create))
            {
                await newImage.CopyToAsync(fileStream);
            }
            oldImage.Link = "https://localhost:44327" + path;
            unit.Thumbnails.Update(mapper.Map<Thumbnail>(oldImage));
            unit.Save();
            
        }

        public async Task UploadImages(IHostingEnvironment _appEnvironment, IFormFile[] images, UserDTO user)
        {
            var mapper = new Mapper(config);
            foreach (var image in images)
            {
                await UploadImage(_appEnvironment, image, user);
            }
            unit.Save();
        }

        public async Task UploadProfilePicture(IHostingEnvironment _appEnvironment, IFormFile image, UserDTO user)
        {
            var mapper = new Mapper(config);
            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
            string path = "/Images/" + fileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            ThumbnailDTO uploadedImage = new ThumbnailDTO { Link = "https://localhost:44327" + path, UserId = user };
            await unit.Thumbnails.Create(mapper.Map<Thumbnail>(uploadedImage));
            unit.Save();
        }

       
        private async Task UploadImage(IHostingEnvironment _appEnvironment, IFormFile image, UserDTO user)
        {
            var mapper = new Mapper(config);
            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
            string path = "/Images/" + fileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            ImageDTO uploadedImage = new ImageDTO { Link = "https://localhost:44327" + path, UserId = user };
            await unit.Images.Create(mapper.Map<Image>(uploadedImage));
        }
    }
}
