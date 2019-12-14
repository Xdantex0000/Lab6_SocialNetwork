using SocialNetwork_DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork_BLL.DTO
{
    public class PersonDTO
    {
        [Column("PersonId")]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public virtual ICollection<Friend> FriendsList { get; set; }
        public virtual ICollection<Invite> InvitesList { get; set; }
    }
}
