using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SocialNetwork_BLL.DTO;
using SocialNetwork_BLL.Services;
using System.Security.Claims;
using Newtonsoft.Json;

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        public IConfiguration Configuration { get; }
        private ChatService chatService;
        public ChatController(IConfiguration configuration)
        {
            this.Configuration = configuration;
            chatService = new ChatService(Configuration.GetConnectionString("sqlConnection"));
        }
        [Authorize]
        [HttpPost("AddMessage")]
        public void AddMessage()
        {
            var message = Request.Form["Message"];
            var username = Request.Form["FriendLogin"];

            List <MessageDTO> messageDTOs = new List<MessageDTO>();
            foreach (var x in message) messageDTOs.Add(new MessageDTO() { Message_Data=x });
            chatService.AddMessage(new DuoChatDTO() { PersonLogin1 = User.Identity.Name, PersonLogin2 = username, Messages = messageDTOs });

            return;
        }
        [HttpPost("GetMessages")]
        public async void GetMessages()
        {
            var username = Request.Form["FriendLogin"];
            List<string> fr = new List<string>();
            foreach (var x in chatService.GetMessages(new DuoChatDTO() { PersonLogin1=username, PersonLogin2= User.Identity.Name }))
                fr.Add(x.Message_Data);

            Response.ContentType = "application/x-www-form-urlencoded";
            await Response.WriteAsync(JsonConvert.SerializeObject(fr, new JsonSerializerSettings { Formatting = Formatting.Indented }));

            return;
        }
    }
}