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
    public class FriendsController : ControllerBase
    {
        IMapper mapper;
        IFriendService friendService;
        IUserService userService;
        public FriendsController(IMapper mapper,IFriendService friendService,IUserService userService)
        {
            this.mapper = mapper;
            this.friendService = friendService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfileModel>> GetFriends()
        {
            return mapper.Map<IEnumerable<ProfileModel>>(await friendService.GetFriends(await userService.GetUserByEmail(User.Identity.Name)));
        }

        [HttpPost("/block")]
        public async Task<IActionResult> Block(ProfileModel profile)
        {
            await friendService.Block(mapper.Map<UserDTO>(profile));
            return Ok();
        }
    }
}