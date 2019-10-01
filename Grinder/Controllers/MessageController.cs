using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grinder.BLL.Interfaces;
using Grinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        IMessageService messageService;
        IMapper mapper;
        public MessageController(IMessageService messageService,IMapper mapper)
        {
            this.messageService = messageService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<MessageModel>> Get()
        {
            messageService.GetConversations();
        }
    }
}