using System;
using System.Collections.Generic;
using System.Text;

namespace KantimeEvv.Models
{
    public class ChatHistoryModel
    {
        public int Id { get; set; }
        public string ChatName { get; set; }
        public string Initial { get; set; }
        public string LastMessage { get; set; }
        public string SentTime { get; set; }
        
    }
}
