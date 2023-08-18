using System;
using Domain.UserDomain;

namespace Domain.ThreadDomain
{
    public class Thread
    {
        public int ThreadId { get;private set; }
        public int MessageCount { get; private set; }
        public User Owner { get; private set; }
        public Message LastMessage { get; private set; }
        public bool IsClosed { get; private set; }
        // Other thread-related properties
    }

}

