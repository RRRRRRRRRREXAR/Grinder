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
        IWebHostEnvironment hostingEnviroment;
        public ImageController(IMapper mapper,IImageService imageService, IWebHostEnvironment hostingEnviroment,IUserService userService)
        {
            this.imageService = imageService;
            this.mapper = mapper;
            this.hostingEnviroment = hostingEnviroment;
            this.userService = userService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<ProfileImage>> Get()
        {
            return mapper.Map<IEnumerable<ProfileImage>>(await imageService.GetImages(await userService.GetUserByEmail(User.Identity.Name)));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile image)
        {
            await imageService.UploadImage(hostingEnviroment.ContentRootPath, image, User.Identity.Name);
            return Ok();
        }
        [Authorize]
        [HttpPost("/uploadprofilepicture")]
        public async Task<IActionResult> UploadProfilePicture(IFormFile image)
        {
            await imageService.UploadProfilePicture(hostingEnviroment.ContentRootPath, image,User.Identity.Name);
            return Ok();
        }
        [Authorize]
        [HttpPost("/updateprofilepicture")]
        public async Task<IActionResult> UpdateProfilePicture(ThumbnailModel profilePicture,IFormFile image)
        {
            await imageService.UpdateProfilePicture(hostingEnviroment.ContentRootPath, image, mapper.Map<ThumbnailDTO>(profilePicture), User.Identity.Name);
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await imageService.DeleteImage(id, hostingEnviroment.ContentRootPath);
            return Ok();
        }
    }
}