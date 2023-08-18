using Domain.UserDomain;

namespace Domain.ThreadDomain
{
    public class Message
    {
        public string Body { get; set; }
        public bool HasFile { get; set; }
        public bool IsReplay { get; set; }
        public User Owner { get; set; }
        // Other message-related properties
    }

}

