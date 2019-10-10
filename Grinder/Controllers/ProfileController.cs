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
    
    public class ProfileController : ControllerBase
    {
        IMapper mapper;
        IUserService userService;

        public ProfileController(IMapper mapper,IUserService userService,IImageService imageService)
        {
            this.userService = userService;
            this.mapper = mapper;
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(UserModel updateProfile)
        {
            await userService.UpdateProfile(mapper.Map<UserDTO>(updateProfile));
            return Ok();
        }
        [HttpGet]
        [Authorize]
        public async Task<ProfileModel> Get(string Email)
        {
           return mapper.Map<ProfileModel>(await userService.GetUserByEmail(Email));
        }

        
    }
}