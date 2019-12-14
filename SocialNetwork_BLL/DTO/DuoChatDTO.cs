using Abp.AutoMapper;
using SocialNetwork_DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork_BLL.DTO
{
    public class DuoChatDTO
    {
        [Column("ChatId")]
        public Guid Id { get; set; }
        public string PersonLogin1 { get; set; }
        public string PersonLogin2 { get; set; }
        public virtual ICollection<MessageDTO> Messages { get; set; }
    }
}
