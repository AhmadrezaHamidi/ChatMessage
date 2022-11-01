using System;

namespace AhmadBase.Core.Domain
{
    public class ThreadDomian
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public int MessageCount { get; set; }
        public string FirstMessageId { get; set; }
        public string LastMessageId { get; set; }
        public DateTime? LastMessageCreateAt { get; set; }
        public bool IsClosed { get; set; }
        public string Key { get; set; }

    }
}