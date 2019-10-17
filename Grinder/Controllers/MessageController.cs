using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using Grinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        IMessageService messageService;
        IUserService userService;
        IMapper mapper;
        public MessageController(IMessageService messageService,IMapper mapper,IUserService userService)
        {
            this.messageService = messageService;
            this.mapper = mapper;
            this.userService = userService;
        }
        [HttpGet]
        public async Task<Dictionary<string,List<MessageDTO>>> GetConversations()
        {
           return await messageService.GetConversations(mapper.Map<UserDTO>(await userService.GetUserByEmail(User.Identity.Name)));
        }

    }
}