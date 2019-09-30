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
    public class UserService : IUserService
    {
        readonly IUnitOfWork unit;
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
        });
        public UserService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public async Task UploadImages(IHostingEnvironment _appEnvironment, IFormFile[] images, UserDTO user)
        {
            var mapper = new Mapper(config);
            foreach(var image in images)
            {
               await UploadImage(_appEnvironment, image, user);
            }
            unit.Save();
        }

        public async Task UploadProfilePicture(IHostingEnvironment _appEnvironment, IFormFile image, UserDTO user)
        {
            var mapper = new Mapper(config);
            await UploadImage(_appEnvironment,image,user);
        }

        public Task UpdateProfile(UserDTO user)
        {
            var mapper = new Mapper(config);
            Task updateTask = Task.Run(() =>
            {
                unit.Users.Update(mapper.Map<User>(user));
                unit.Save();
            });
            return updateTask;
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
            ImageDTO uploadedImage = new ImageDTO { Link = "https://localhost:44327" + path, UserId=user };
            await unit.Images.Create(mapper.Map<Image>(uploadedImage));
        }
    }
}
