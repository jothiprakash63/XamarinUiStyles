using System;
using System.Collections.Generic;
using System.Text;

namespace KantimeEvv.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public bool IsSent { get; set; }
        public string Message { get; set; }
        public string SentOn { get; set; }
      

    }
}
