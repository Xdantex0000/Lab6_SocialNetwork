using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork_BLL.DTO;
using SocialNetwork_DAL.Entities.Models;

namespace SocialNetwork_BLL.Interfaces
{
    interface IFriendsService
    {
        ICollection<Friend> FriendsGet(PersonDTO person);
        ICollection<InviteDTO> InvitesGet(PersonDTO person);
    }
}
