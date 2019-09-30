using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using Grinder.BLL.MapProfile;
using Grinder.DAL.Entities;
using Grinder.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Services
{
    public class FriendService : IFriendService
    {
        IUnitOfWork unit;
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
        });
        public Task AcceptInvite(FriendsDTO friends)
        {
            var mapper = new Mapper(config);
            friends.Status = "Friends";
            Task updateTask = Task.Run(() =>
            {
                unit.Friends.Update(mapper.Map<Friends>(friends));
                unit.Save();
            });
            return updateTask;
            
        }

        public Task Block(FriendsDTO friends)
        {
            var mapper = new Mapper(config);
            friends.Status = "Blocked";
            Task updateTask = Task.Run(() =>
            {
                unit.Friends.Update(mapper.Map<Friends>(friends));
                unit.Save();
            });
            return updateTask;
        }

        public Task DeclineInvite(FriendsDTO friends)
        {
            var mapper = new Mapper(config);
            friends.Status = "Declined";
            Task updateTask = Task.Run(() =>
            {
                unit.Friends.Update(mapper.Map<Friends>(friends));
                unit.Save();
            });
            return updateTask;
        }

        public Task<IEnumerable<UserDTO>> GetFriends(UserDTO owner)
        {
            var mapper = new Mapper(config);
            unit.Friends.FindMany();
        }

        public Task SendInvite(UserDTO sender, UserDTO recivier)
        {
            throw new NotImplementedException();
        }
    }
}
