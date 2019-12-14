using Microsoft.EntityFrameworkCore;
using SocialNetwork_DAL.Entities;
using SocialNetwork_DAL.Entities.Models;
using SocialNetwork_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SocialNetwork_DAL.Repositiories
{
    public class ChatRepository : IRepository<DuoChat>
    {
        private ApplicationContext db;

        public ChatRepository(ApplicationContext context)
        {
            this.db = context;
        }
        public void Create(DuoChat item)
        {
            db.DuoChat.Add(new DuoChat() { PersonLogin1=item.PersonLogin1, PersonLogin2=item.PersonLogin2, Messages= new List<Message>() { new Message() { Message_Data=item.PersonLogin1+": "+item.Messages.FirstOrDefault(x=>x.Message_Data!="").Message_Data } } });
        }

        public void Delete(string item)
        {
            DuoChat message = db.DuoChat.Find(item);
            if (message != null)
                db.DuoChat.Remove(message);
        }
        public DuoChat Get(DuoChat item)
        {
            return db.DuoChat.FirstOrDefault(x => x.PersonLogin1 == item.PersonLogin1 && x.PersonLogin2 == item.PersonLogin2);
        }

        public ICollection<DuoChat> GetAll()
        {
            return db.DuoChat.ToList()  ;
        }

        public void Update(DuoChat item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
