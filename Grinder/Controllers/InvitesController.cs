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
    public class InvitesController : ControllerBase
    {
        IMapper mapper;
        IFriendService friendService;
        IUserService userService;
        public InvitesController(IMapper mapper,IFriendService friendService,IUserService userService)
        {
            this.mapper = mapper;
            this.friendService = friendService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<FriendsModel>> GetInvites()
        {
            return mapper.Map<IEnumerable<FriendsModel>>(await friendService.GetInvites(await userService.GetUserByEmail(User.Identity.Name)));
        }

        [HttpPost]
        public async Task<IActionResult> Invite(ProfileModel invite)
        {
            await friendService.SendInvite(User.Identity.Name, invite.Email);
            return Ok();
        }

        [HttpPost("/acceptinvite")]
        public async Task<IActionResult> AcceptInvite(FriendsModel friends)
        {
            if (friends.Sender.Email!=User.Identity.Name)
            {
                await friendService.AcceptInvite(mapper.Map<FriendsDTO>(friends));

            }
            return Ok();
        }
        [HttpPost("/declineinvite")]
        public async Task<IActionResult> DeclineInvite(FriendsModel friends)
        {
            if (friends.Sender.Email != User.Identity.Name)
            {
                await friendService.DeclineInvite(mapper.Map<FriendsDTO>(friends));
            }
            return Ok();
        }
        
    }
}