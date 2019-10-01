using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using Grinder.BLL.MapProfile;
using Grinder.DAL.Entities;
using Grinder.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Grinder.BLL.Services
{
    public class MessageService : IMessageService
    {
        IUnitOfWork unit;
        readonly MapperConfiguration config = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new UserProfile());
        });
        public MessageService(IUnitOfWork unit)
        {
            this.unit = unit;
        }
        public async Task<IEnumerable<MessageDTO>> GetConversation(UserDTO sender, UserDTO recivier)
        {
            var mapper = new Mapper(config);
            IEnumerable<MessageDTO> Messages= mapper.Map<IEnumerable<MessageDTO>>(await unit.Messages.FindMany(d=>d.Sender==mapper.Map<User>(sender) && d.Recivier==mapper.Map<User>(recivier)));
            return Messages;
        }
        //TODO 
        //THIS PLS
        public async Task<IEnumerable<MessageDTO>> GetConversations(UserDTO owner)
        {
            var mapper = new Mapper(config);
            var AllMessages = await unit.Messages.FindMany(d=>d.Sender==mapper.Map<User>(owner) || d.Recivier == mapper.Map<User>(owner));
            AllMessages.

        }

        public async Task SendMessage(MessageDTO message)
        {
            var mapper = new Mapper(config);
            await unit.Messages.Create(mapper.Map<Message>(message));
            unit.Save();
        }
    }
}
