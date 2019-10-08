using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using Grinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Grinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ImageController : ControllerBase
    {
        IMapper mapper;
        IImageService imageService;
        IUserService userService;
        IHostingEnvironment hostingEnviroment;
        public ImageController(IMapper mapper,IImageService imageService,IHostingEnvironment hostingEnviroment,IUserService userService)
        {
            this.imageService = imageService;
            this.mapper = mapper;
            this.hostingEnviroment = hostingEnviroment;
            this.userService = userService;
        }

        public async Task<IActionResult> Post(IFormFile[] images)
        {
            await imageService.UploadImages(hostingEnviroment, images, await userService.GetUserByEmail(User.Identity.Name));
            return Ok();
        }
        [HttpPost("/uploadprofilepicture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile image)
        {
            await imageService.UploadProfilePicture(hostingEnviroment, image, await userService.GetUserByEmail(User.Identity.Name));
            return Ok();
        }
        [HttpPost("/updateprofilepicture")]
        public async Task<IActionResult> UpdateProfilePicture(ThumbnailModel profilePicture,IFormFile image)
        {
            await imageService.UpdateProfilePicture(hostingEnviroment, image, mapper.Map<ThumbnailDTO>(profilePicture));
            return Ok();
        }
        public async Task<IActionResult> Delete(int id)
        {
            await imageService.DeleteImage(id, hostingEnviroment);
            return Ok();
        }
    }
}