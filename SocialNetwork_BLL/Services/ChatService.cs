using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork_BLL.DTO;
using SocialNetwork_BLL.Interfaces;
using SocialNetwork_DAL.Entities.Models;
using SocialNetwork_DAL.UnitOfWork;
using SocialNetwork_BLL.Mappers;
using System.Linq;

namespace SocialNetwork_BLL.Services
{
    public class ChatService : IChatService
    {
        private UnitOfWork Database;

        public ChatService(string conString)
        {
            Database = new UnitOfWork(conString);
        }

        public ICollection<Message> GetMessages(DuoChatDTO item)
        {
            if (Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin1 && x.PersonLogin2 == item.PersonLogin2 || x.PersonLogin1 == item.PersonLogin2 && x.PersonLogin2 == item.PersonLogin1) == null)
                return new List<Message>() { };
            if (Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin1 && x.PersonLogin2 == item.PersonLogin2) != null)
                return Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin1 && x.PersonLogin2 == item.PersonLogin2).Messages;
            if (Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin2 && x.PersonLogin2 == item.PersonLogin1) != null)
                return Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin2 && x.PersonLogin2 == item.PersonLogin1).Messages;
            return new List<Message>(){};
        }
        public void AddMessage(DuoChatDTO item)
        {
            if (Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin1 && x.PersonLogin2 == item.PersonLogin2 || x.PersonLogin1 == item.PersonLogin2 && x.PersonLogin2 == item.PersonLogin1) == null)
                Database.Chat.Create(CustomMapper.ChatMapper().Map<DuoChatDTO, DuoChat>(item));
            foreach (var x in item.Messages)
            {
                if (Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin1 && x.PersonLogin2 == item.PersonLogin2) != null)
                {
                    Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin1 && x.PersonLogin2 == item.PersonLogin2).Messages.Add(new Message() { Message_Data = $"{item.PersonLogin1}: {x.Message_Data}" });
                    break;
                }
                if (Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin2 && x.PersonLogin2 == item.PersonLogin1) != null)
                {
                    Database.Chat.GetAll().FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin2 && x.PersonLogin2 == item.PersonLogin1).Messages.Add(new Message() { Message_Data = $"{item.PersonLogin1}: {x.Message_Data}" });
                    break;
                }
            }
            Database.Save();
        }
    }
}
