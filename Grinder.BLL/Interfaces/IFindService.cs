using Grinder.BLL.DTO;
using Grinder.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IFindService
    {
        Task<IEnumerable<UserDTO>> GetUsersBy(Expression<Func<User,bool>> predicate);
    }
}
