using Grinder.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IFriendService
    {
        Task SendInvite(UserDTO sender,UserDTO recivier);
        Task AcceptInvite(FriendsDTO friends);
        Task DeclineInvite(FriendsDTO friends);
        Task Block(FriendsDTO friends);
        Task<IEnumerable<FriendsDTO>> GetFriends(UserDTO owner);
    }
}
