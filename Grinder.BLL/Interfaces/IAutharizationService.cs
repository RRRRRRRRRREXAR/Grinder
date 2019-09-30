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
        Task<UserDTO> Login(string password,string email);
        Task<UserDTO> GetUserByEmail(string email);
    }
}
