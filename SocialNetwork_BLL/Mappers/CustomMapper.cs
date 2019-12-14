using AutoMapper;
using SocialNetwork_BLL.DTO;
using SocialNetwork_DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork_BLL.Mappers
{
    public class CustomMapper
    {
        public static IMapper PersonMapper()
        {
            // Creating configuration for mapper
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<FriendDTO, Friend>().ReverseMap();
                cfg.CreateMap<InviteDTO, Invite>().ReverseMap();
                cfg.CreateMap<PersonDTO, Person>().ReverseMap();

            });
            // Creating mapper
            return configuration.CreateMapper();
        }
        public static IMapper MessageMapper()
        {
            // Creating configuration for mapper
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<MessageDTO, Message>()
                .ReverseMap();
            });
            // Creating mapper
            return configuration.CreateMapper();
        }
        public static IMapper FriendsMapper()
        {
            // Creating configuration for mapper
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<FriendDTO, Friend>()
                .ReverseMap();
            });
            // Creating mapper
            return configuration.CreateMapper();
        }
        public static IMapper InviteMapper()
        {
            // Creating configuration for mapper
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<InviteDTO, Invite>()
                .ReverseMap();
            });
            // Creating mapper
            return configuration.CreateMapper();
        }
        public static IMapper ChatMapper()
        {
            // Creating configuration for mapper
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<MessageDTO, Message>().ReverseMap();
                cfg.CreateMap<DuoChatDTO, DuoChat>().ReverseMap();
            });
            // Creating mapper
            return configuration.CreateMapper();
        }
        public static IMapper InviteCollectionMapper()
        {
            // Creating configuration for mapper
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<ICollection<Invite>, InviteDTO>()
                .ReverseMap();
            });
            // Creating mapper
            return configuration.CreateMapper();
        }
        public static IMapper InviteRequestMapper()
        {
            // Creating configuration for mapper
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<InviteRequestDTO, InviteRequest>()
                .ReverseMap();
            });
            // Creating mapper
            return configuration.CreateMapper();
        }
        public static IMapper FriendRequestMapper()
        {
            // Creating configuration for mapper
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<FriendRequestDTO, FriendRequest>()
                .ReverseMap();
            });
            // Creating mapper
            return configuration.CreateMapper();
        }

    }
}
