using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork_DAL.Entities.Models
{
    public class DuoChat
    {
        [Column("ChatId")]
        public Guid Id { get; set; }
        public string PersonLogin1 { get; set; }
        public string PersonLogin2 { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
