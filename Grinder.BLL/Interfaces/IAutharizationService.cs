using Grinder.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IAutharizationService
    {
        Task Register(UserDTO user);
        Task Login(string password,string email);
        Task GetUserByEmail(string email);
    }
}
