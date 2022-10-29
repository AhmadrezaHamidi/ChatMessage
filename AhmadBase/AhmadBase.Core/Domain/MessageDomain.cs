using System;
using System.Collections.Generic;
using System.Text;

namespace AhmadBase.Core.Domain
{
    public class MessageDomain
    {


        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string ThreadId { get; set; }
        public string Body { get; set; }
        public string OwnerId { get; set; }
        public bool HasReplay { get; set; }
        public bool Seen { get; set; }
        public string ReplayMessageId { get; set; }



        public string ThraedId { get; set; }
        public ThreadDomian Thread { get; set; }
    }
}
