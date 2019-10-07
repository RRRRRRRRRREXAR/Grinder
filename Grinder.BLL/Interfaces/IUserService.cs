using Grinder.BLL.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByEmail(string Email);
        Task UpdateProfile(UserDTO user);
    }
}
