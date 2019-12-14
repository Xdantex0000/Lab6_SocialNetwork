using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork_DAL.Interfaces;
using SocialNetwork_DAL.Entities.Models;
using SocialNetwork_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SocialNetwork_DAL.Repositiories
{
    public class PersonRepository : IRepository<Person>
    {
        private ApplicationContext db;

        public PersonRepository(ApplicationContext context)
        {
            this.db = context;
        }

        public void Create(Person item)
        {
            if (Get(new Person() { Login=item.Login }) == null)
                db.People.Add(new Person() { Login = item.Login, Password = item.Password, Role = item.Role });
            else
                throw new ValidationException("User already in Data Base");

        }

        public void Delete(string item)
        {
            Person person = db.People.Find(item);
            if (person != null)
                db.People.Remove(person);
        }

        public Person Get(Person item)
        {
            var person = db.People.FirstOrDefault(x=>x.Login==item.Login);
            if (person == null) return null;
            if (item.Password == null) return new Person();
            if (person.Password==item.Password) return person;
            else return null;

        }
        public void Invite(InviteRequest invite)
        {
            
        }

        public ICollection<Person> GetAll()
        {
            return db.People.ToList();
        }
        public void Delete(FriendRequest item)
        {
            db.Invite.FirstOrDefault(x => x.Inviter_Login == item.FriendLogin1).InviteId = Guid.Empty;
        }
        public void Update(Person person)
        {
            db.Entry(person).State = EntityState.Modified;
        }
    }
}
