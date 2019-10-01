using Grinder.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IDataService
    {
        Task<int> GetViews(int id);
        Task<double> GetReplyRate(int id);
        Task AddView(UserDTO user,UserDTO profile);
    }
}
