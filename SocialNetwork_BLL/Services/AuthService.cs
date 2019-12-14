using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork_BLL.DTO;
using SocialNetwork_DAL.Entities.Models;
using SocialNetwork_BLL.Interfaces;
using SocialNetwork_DAL.UnitOfWork;
using AutoMapper;
using SocialNetwork_BLL.Infrastructure;
using SocialNetwork_BLL.Mappers;
using System.Linq;

namespace SocialNetwork_BLL.Services
{
    public class AuthService : IAuthService
    {
        private UnitOfWork Database;

        public AuthService(string conString)
        {
            Database = new UnitOfWork(conString);
        }
        public void CreatePerson(string Login, string Password)
        {
            PersonDTO person = new PersonDTO() { Login = Login, Password = Password, Role = "user" };
            if(Database.Persons.GetAll().FirstOrDefault(x=>x.Login==Login)==null)
                Database.Persons.Create(CustomMapper.PersonMapper().Map<PersonDTO, Person>(person));
            Database.Save();
        }
        public PersonDTO GetPerson(string? username, string? password)
        {

            if (username == null)
                throw new ValidationException("Не установлено значение username", "");
            if (password == null)
                throw new ValidationException("Не установлено значение password", "");
            var person = Database.Persons.Get(CustomMapper.PersonMapper().Map<PersonDTO, Person>(new PersonDTO() { Login = username, Password = password }));
            if (person == null)
                throw new ValidationException("Пользователь не найден", "");

            return new PersonDTO { Login = person.Login, Password = person.Password, Role = person.Role };
        }
        public ICollection<PersonDTO> GetPeople(string GetterLogin)
        {
            return CustomMapper.PersonMapper().Map<ICollection<Person>,ICollection<PersonDTO>>(Database.Persons.GetAll().Except(Database.Persons.GetAll().Where(x=>x.FriendsList.FirstOrDefault(x=>x.Friend1_Login==GetterLogin || x.Friend2_Login==GetterLogin)!=null)).ToList());
        }
        public IEnumerable<PersonDTO> GetPersons()
        {
            return CustomMapper.PersonMapper().Map<IEnumerable<Person>,IEnumerable<PersonDTO>>(Database.Persons.GetAll());
        }
    }
}
