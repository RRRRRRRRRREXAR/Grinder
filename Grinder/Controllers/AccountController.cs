using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Grinder.BLL.DTO;
using Grinder.BLL.Interfaces;
using Grinder.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Grinder.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAutharizationService autorizeService;
        IMapper mapper;
        IUserService userService;
        public AccountController(IAutharizationService autharizationService,IUserService userService,IMapper mapper)
        {
            this.autorizeService = autharizationService;
            this.mapper = mapper;
            this.userService = userService;
        }

        [HttpPost("/token")]
        public async Task Token()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var identity = GetIdentity(username, password);
            if (identity == null)
            {
                Response.StatusCode = 400;
                await Response.WriteAsync("Invalid username or password.");
                return;
            }
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            Response.ContentType = "application/json";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));

        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegistrationModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await autorizeService.Register(mapper.Map<UserDTO>(user));
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<UpdateProfileModel> Get()
        {
            return mapper.Map<UpdateProfileModel>(await userService.GetUserByEmail(User.Identity.Name));
        }
        private ClaimsIdentity GetIdentity(string username,string password)
        {
            UserDTO person = autorizeService.Login(password, username).Result;
            if (person!=null)
            {
                var claims = new List<Claim>
                {
                     new Claim(ClaimsIdentity.DefaultNameClaimType,person.Email),
                     new Claim(ClaimsIdentity.DefaultRoleClaimType,person.Role)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
        [HttpPost("/changepassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {
           await autorizeService.ChangePassword(User.Identity.Name,model.OldPassword,model.NewPassword);
            return Ok();
        }
    }
}