using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork_DAL.Entities.Models
{
    public class Friend
    {
        public Guid FriendId { get; set; }
        public string Friend1_Login { get; set; }
        public string Friend2_Login { get; set; }
    }
}
