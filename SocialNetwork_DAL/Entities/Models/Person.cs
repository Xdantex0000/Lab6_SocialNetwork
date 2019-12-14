using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork_DAL.Entities.Models
{
    public class Person
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
