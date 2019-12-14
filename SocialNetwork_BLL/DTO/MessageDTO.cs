using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork_BLL.DTO
{
    public class MessageDTO
    {
        [Column("MessageId")]
        public Guid Id { get; set; }
        public string Message_Data { get; set; }
    }
}
