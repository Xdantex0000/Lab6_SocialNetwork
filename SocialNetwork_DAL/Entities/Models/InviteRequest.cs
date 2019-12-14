using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork_DAL.Entities.Models
{
    public class InviteRequest
    {
        public string Login { get; set; }
        public string InviterLogin { get; set; }
    }
}
