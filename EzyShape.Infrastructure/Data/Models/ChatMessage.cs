using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Infrastructure.Data.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public string SenderId { get; set; }  // Id of Sender
        public string ReceiverId { get; set; }  // Id of receiver
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; }
    }
}
