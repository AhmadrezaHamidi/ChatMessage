using Domain.UserDomain;

namespace Domain.ThreadDomain
{
    public class ThreadParticipant
    {
        public string Role { get; set; }
        public User User { get; set; }
        public DateTime LastSeen { get; set; }
    }

}

