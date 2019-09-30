using Grinder.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Interfaces
{
    public interface IMessageService
    {
        Task SendMessage(MessageDTO message);
        Task<IEnumerable<MessageDTO>> GetConversations(UserDTO owner);
        Task<IEnumerable<MessageDTO>> GetConversation(UserDTO sender,UserDTO recivier);
    }
}
