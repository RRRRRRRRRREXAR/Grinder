using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Services
{
    public class AutharizationService : IAutharizationService
    {
        public Task<UserDTO> GetUserByEmail(string email)
        {
            
        }

        public Task Login(string password, string email)
        {
            throw new NotImplementedException();
        }

        public Task Register(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
