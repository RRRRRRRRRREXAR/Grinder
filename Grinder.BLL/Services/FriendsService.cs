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
        public FriendService(IUnitOfWork unit)
        {
            this.unit = unit;
        }

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

        public async Task Block(UserDTO profile)
        {
            var mapper = new Mapper(config);
            Friends friends = await unit.Friends.Find(f=>f.Sender==mapper.Map<User>(profile) || f.Recivier == mapper.Map<User>(profile));
            friends.Status = "Blocked";
            await unit.Friends.Delete(friends.Id);
            unit.Save();
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

        public async Task<List<UserDTO>> GetFriends(UserDTO owner)
        {
            var mapper = new Mapper(config);
            var fef = await unit.Friends.FindMany(d => d.Sender == mapper.Map<User>(owner) || d.Recivier == mapper.Map<User>(owner) && d.Status == "Friends",f=>f.Recivier.ProfileImage,f=>f.Sender.ProfileImage);
            return mapper.Map<List<UserDTO>>(SortFriends(fef,mapper.Map<User>(owner)));
        }

        private List<User> SortFriends(List<Friends> frens,User owner)
        {
            List<User> sortedFrens = new List<User>();
            foreach(var fren in frens)
            {
                if (fren.Sender.Email!=owner.Email)
                {
                    sortedFrens.Add(fren.Sender);
                }
                if (fren.Recivier.Email != owner.Email)
                {
                    sortedFrens.Add(fren.Recivier);
                }
            }
            return sortedFrens;
        }
        public async Task SendInvite(string senderUsername, string recivierUsername)
        {
            var mapper = new Mapper(config);
            await unit.Friends.Create(new Friends
            {
                Status = "Pending",
                Sender = await unit.Users.Find(d => d.Email == senderUsername),
                Recivier = await unit.Users.Find(d => d.Email == recivierUsername)
            });
            unit.Save();
        }

        public async Task<IEnumerable<FriendsDTO>> GetInvites(UserDTO owner)
        {
            var mapper = new Mapper(config);
            var friends= mapper.Map<IEnumerable<FriendsDTO>>(await unit.Friends.FindMany(d => d.Recivier == mapper.Map<User>(owner) && d.Status == "Pending",d=>d.Sender,d=>d.Sender.ProfileImage));
            return friends;
        }

        
    }
}
