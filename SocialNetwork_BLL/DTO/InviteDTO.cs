﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork_BLL.DTO
{
    public class InviteDTO
    {
        public Guid InviteId { get; set; }
        public string Inviter_Login { get; set; }
        public string Invited_Login { get; set; }
    }
}
