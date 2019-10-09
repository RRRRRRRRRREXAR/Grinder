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

        public async Task<UserDTO> GetUserByEmail(string Email)
        {
            var mapper =new Mapper(config);
            var user = await unit.Users.Find(d => d.Email == Email);
            user.Password = null;
            return mapper.Map<UserDTO>(user);
        }
        /// <summary>
        /// user.Email && and password = null
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task UpdateProfile(UserDTO user)
        {
            var mapper = new Mapper(config);
            if (user.Images.Count==0&&user.ProfileImage==null)
            {
               var tempUser= await unit.Users.Get(user.Id);
                if (tempUser.Images==null)
                {
                    user.Images = mapper.Map<ICollection<ImageDTO>>(tempUser.Images);
                }
                user.ProfileImage = mapper.Map<ThumbnailDTO>(tempUser.ProfileImage);
                if (user.Password==null)
                {
                    user.Password = tempUser.Password;
                }
                user.Email = tempUser.Email;
            }
            
            await Task.Run(() =>
            {
                unit.Users.Update(mapper.Map<User>(user));
                unit.Save();
            });
        }
    }
}
