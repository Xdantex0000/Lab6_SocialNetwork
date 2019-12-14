using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork_BLL.DTO;
using SocialNetwork_BLL.Interfaces;
using SocialNetwork_DAL.UnitOfWork;
using System.Linq;
using AutoMapper;
using SocialNetwork_DAL.Entities.Models;
using SocialNetwork_BLL.Mappers;
using System.Linq;

namespace SocialNetwork_BLL.Services
{
    public class FriendsService : IFriendsService
    {
        private UnitOfWork Database;

        public FriendsService(string conString)
        {
            Database = new UnitOfWork(conString);
        }

        public ICollection<Friend> FriendsGet(PersonDTO person)
        {
            return Database.Persons.GetAll().FirstOrDefault(x => x.Login == person.Login).FriendsList;
        }

        public ICollection<InviteDTO> InvitesGet(PersonDTO person)
        {
            return CustomMapper.InviteMapper().Map<ICollection<Invite>,ICollection<InviteDTO>>(Database.Persons.GetAll().FirstOrDefault(x => x.Login == person.Login).InvitesList);
        }
       
        public void InvitesAdd(InviteRequestDTO item)
        {
            if (Database.Persons.GetAll().FirstOrDefault(x => x.Login == item.Login).InvitesList.FirstOrDefault(x => x.Inviter_Login == item.InviterLogin) == null)
                Database.Persons.GetAll().FirstOrDefault(x => x.Login == item.Login).InvitesList.Add(new Invite() { Invited_Login = item.Login, Inviter_Login = item.InviterLogin });
            Database.Save();
        }
        public void FriendAdd(FriendRequestDTO item)
        {
            var Id = Database.Persons.GetAll().FirstOrDefault(x=>x.Login==item.FriendLogin2).InvitesList.FirstOrDefault(x=>x.Inviter_Login==item.FriendLogin1).InviteId;
            var person = Database.Persons.GetAll().FirstOrDefault(x => x.Login == item.FriendLogin2);
            if (person.FriendsList.FirstOrDefault(x => x.Friend2_Login == item.FriendLogin1) == null)
            {
                Database.Persons.GetAll().FirstOrDefault(x => x.Login == item.FriendLogin2).FriendsList.Add(new Friend() { Friend1_Login = item.FriendLogin2, Friend2_Login = item.FriendLogin1 });
                Database.Persons.GetAll().FirstOrDefault(x => x.Login == item.FriendLogin1).FriendsList.Add(new Friend() { Friend1_Login = item.FriendLogin1, Friend2_Login = item.FriendLogin2 });
                if (person.InvitesList.FirstOrDefault(x => x.Inviter_Login == item.FriendLogin1) != null)
                {
                    Database.Persons.GetAll().FirstOrDefault(x => x.Login == item.FriendLogin2).InvitesList = Database.Persons.GetAll().FirstOrDefault(x => x.Login == item.FriendLogin2).InvitesList.Where(x=>x.Inviter_Login!=item.FriendLogin1).ToList();
                }
            }


            Database.Save();
        }
    }
}
