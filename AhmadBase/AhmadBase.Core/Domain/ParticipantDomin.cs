using System;

namespace AhmadBase.Core.Domain
{
    public class ParticipantDomin  
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public string ThreadId { get; set; }
        public string UserId { get; set; }
        public ParticipantRoleEnum Role { get; set; }
        public int MessageCount { get; set; }

    }
}