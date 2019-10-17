using Grinder.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IFriendService
    {
        Task SendInvite(string senderUsername, string recivierUsername);
        Task AcceptInvite(FriendsDTO friends);
        Task DeclineInvite(FriendsDTO friends);
        Task Block(UserDTO profile);
        Task<List<UserDTO>> GetFriends(UserDTO owner);
        Task<IEnumerable<FriendsDTO>> GetInvites(UserDTO owner);
    }
}
