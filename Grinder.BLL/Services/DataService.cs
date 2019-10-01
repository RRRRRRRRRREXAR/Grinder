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
    public class DataService : IDataService
    {
        IUnitOfWork unit;
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
        });
        public DataService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public async Task AddView(UserDTO viewer, UserDTO profile)
        {
            var mapper = new Mapper(config);
            await unit.ProfileViews.Create(new ProfileView {Date=DateTime.Now, Profile=mapper.Map<User>(profile),Viewer=mapper.Map<User>(viewer)});
            unit.Save();
        }

        public async Task<double> GetReplyRate(int id)
        {
            var user = await unit.Users.Find(u=>u.Id==id);

            List<Message> sended = await unit.Messages.FindMany(d => d.Sender == user);
            List<Message> recivied = await unit.Messages.FindMany(d => d.Recivier == user);

            return sended.Count / recivied.Count;
        }

        public async Task<int> GetViews(int id)
        {
            var profile = await unit.Users.Get(id);
            var views= await unit.ProfileViews.FindMany(v => v.Profile == profile);
            return views.Count;
        }

        
    }
}
