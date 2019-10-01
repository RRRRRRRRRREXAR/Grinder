using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using Grinder.BLL.MapProfile;
using Grinder.DAL.Entities;
using Grinder.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Services
{
    public class FindService : IFindService
    {
        IUnitOfWork unit;
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
        });
        public FindService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public async Task<IEnumerable<UserDTO>> GetUsersBy(Expression<Func<User, bool>> predicate)
        {
            var mapper = new Mapper(config);
            var users = await unit.Users.FindMany(predicate);
            return mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}
