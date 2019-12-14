using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using SocialNetwork_BLL.Services;
using SocialNetwork;
using SocialNetwork_BLL.DTO;
using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private AuthService authService;
        private FriendsService friendsService;
        
        public IConfiguration Configuration { get; }
        
        public AccountController(IConfiguration configuration)
        {
            this.Configuration = configuration;
            authService = new AuthService(Configuration.GetConnectionString("sqlConnection"));
            friendsService = new FriendsService(Configuration.GetConnectionString("sqlConnection"));
        }
        #region Invites
        [Authorize]
        [HttpPost("Invite")]
        public void InviteUser()
        {   
            var username = Request.Form["Login"];

            friendsService.InvitesAdd(new InviteRequestDTO() { Login=username, InviterLogin= User.Identity.Name });

            return;
        }
        [Authorize]
        [HttpGet("GetPeople")]
        public async void GetPeople()
        {
            List<string> fr = new List<string>();
            foreach (var x in authService.GetPeople(User.Identity.Name))
            {
                if(x.Login!= User.Identity.Name)
                    fr.Add(x.Login);
            }

            Response.ContentType = "application/x-www-form-urlencoded";
            await Response.WriteAsync(JsonConvert.SerializeObject(fr, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
        [Authorize]
        [HttpGet("GetInvites")]
        public async void GetInvites()
        {
            List<string> fr = new List<string>();
            foreach (var x in friendsService.InvitesGet(new PersonDTO() { Login = User.Identity.Name }))
                fr.Add(x.Inviter_Login);

            Response.ContentType = "application/x-www-form-urlencoded";
            await Response.WriteAsync(JsonConvert.SerializeObject(fr, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
        [Authorize]
        [HttpPost("AddFriend")]
        public void AddFriend()
        {
            var username = Request.Form["FriendLogin"];

            friendsService.FriendAdd(new FriendRequestDTO() { FriendLogin1 = username, FriendLogin2 = User.Identity.Name });

            return;
        }
        [Authorize]
        [HttpGet("GetFriends")]
        public async void GetFriends()
        {
            List<string> fr = new List<string>();
            foreach (var x in friendsService.FriendsGet(new PersonDTO() { Login = User.Identity.Name }))
                fr.Add(x.Friend2_Login);

            Response.ContentType = "application/x-www-form-urlencoded";
            await Response.WriteAsync(JsonConvert.SerializeObject(fr, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
        #endregion
        #region UserMagagement
        [HttpPost("DbUser")]
        public void AddUser()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];

            authService.CreatePerson(username,password);
            return;
        }
        [HttpPost("token")]
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
            // создаем JWT-токен
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

            // сериализация ответа
            Response.ContentType = "application/x-www-form-urlencoded";
            await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }
        #endregion
        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var person = authService.GetPerson(username, password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}