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

        public async Task DeleteImage(int id, string _appEnvironment)
        {
           Image image= await unit.Images.Get(id);
            var imgName = image.Link.Split('/')[4];
            await unit.Images.Delete(id);
            File.Delete(_appEnvironment + "\\Images\\" + imgName);
           unit.Save();
        }

        public async Task DeleteProfilePicture(int id, string _appEnvironment)
        {
            Thumbnail profilePic = await unit.Thumbnails.Get(id);
            var imgName = profilePic.Link.Split('/')[4];
            await unit.Thumbnails.Delete(id);
            File.Delete(_appEnvironment + "\\Images\\" + imgName);
            unit.Save();
        }

        public async Task<IEnumerable<ImageDTO>> GetImages(UserDTO user)
        {
            var mapper = new Mapper(config);
            var images=await unit.Images.FindMany(u => u.UserId == mapper.Map<User>(user));
            return mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public async Task UpdateProfilePicture(string _appEnviroment, IFormFile newImage, ThumbnailDTO oldImage,string user)
        {
            var mapper = new Mapper(config);
            var imgName = oldImage.Link.Split('/')[4];
            File.Delete(_appEnviroment + "\\Images\\" + imgName);
            var fileName = ContentDispositionHeaderValue.Parse(newImage.ContentDisposition).FileName.Trim('"');
            string path = "/Images/" + fileName;
            using (var fileStream = new FileStream(_appEnviroment + path, FileMode.Create))
            {
                await newImage.CopyToAsync(fileStream);
            }
            oldImage.Link = "https://localhost:44340" + path;
            unit.Thumbnails.Update(mapper.Map<Thumbnail>(oldImage));
            unit.Save();
            
        }

        public async Task UploadImage(string _appEnvironment, IFormFile image, string Email)
        {
            var mapper = new Mapper(config);
            var tempUser = await unit.Users.Find(d => d.Email == Email);
            await UploadImage(_appEnvironment, image, tempUser);
            unit.Save();
        }

        public async Task UploadProfilePicture(string _appEnvironment, IFormFile image, string Email)
        {
            var mapper = new Mapper(config);
            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
            string path = "/Images/" + fileName;
            using (var fileStream = new FileStream(_appEnvironment + path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            var user = await unit.Users.Find(d=>d.Email==Email);
            ThumbnailDTO uploadedImage = new ThumbnailDTO { Link = "https://localhost:44340" + path };
            Thumbnail pic = mapper.Map<Thumbnail>(uploadedImage);
            pic.UserId = user;
            await unit.Thumbnails.Create(pic);
            unit.Save();
        }

       
        private async Task UploadImage(string _appEnvironment, IFormFile image, User user)
        {
            var mapper = new Mapper(config);
            var fileName = ContentDispositionHeaderValue.Parse(image.ContentDisposition).FileName.Trim('"');
            string path = "/Images/" + fileName;
            using (var fileStream = new FileStream(_appEnvironment + path, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }
            Image uploadedImage = new Image { Link = "https://localhost:44340" + path, UserId = user};
            await unit.Images.Create(uploadedImage);
        }
    }
}
