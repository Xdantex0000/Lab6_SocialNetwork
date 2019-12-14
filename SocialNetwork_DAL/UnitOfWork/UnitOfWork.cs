using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SocialNetwork_DAL.Entities;
using SocialNetwork_DAL.Repositiories;
using SocialNetwork_DAL.Interfaces;

namespace SocialNetwork_DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext db;
        private PersonRepository personRepository;
        private ChatRepository chatRepository;

        public UnitOfWork(string conString)
        {
           db = new ApplicationContext(conString);
        }

        public PersonRepository Persons
        {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(db);
                return personRepository;
            }
        }
        public ChatRepository Chat
        {
            get
            {
                if (chatRepository == null)
                    chatRepository = new ChatRepository(db);
                return chatRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
