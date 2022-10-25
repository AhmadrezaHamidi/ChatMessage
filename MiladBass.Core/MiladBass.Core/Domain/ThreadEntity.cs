using System;

namespace MiladBass.Core.Domain
{
    public class ThreadEntity : EntityBase
    {
        public int MessageCount { get; set; }
        public string FirstMessageId { get; set; }
        public string LastMessageId { get; set; }
        public DateTime? LastMessageCreateAt { get; set; }
        public bool IsClosed { get; set; }
        public string Key { get; set; }

        public ThreadEntity(Guid ThreadId, int messageCount, string firstMessageId,
            string lastMessageId, DateTime? lastMessageCreateAt)
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = null;
            MessageCount = messageCount;
            FirstMessageId = firstMessageId;
            LastMessageId = lastMessageId;
            LastMessageCreateAt = lastMessageCreateAt;
            IsClosed = false;
            CreatedAt = DateTime.Now;
            Key =null;
        }
        public ThreadEntity()
        {

        }
        public void PluseMessageCount()
        {
            MessageCount += 1;
        }
        public void SetLastMessage(string lastMessageId ,DateTime lastMessageAt)
        {
            LastMessageId = lastMessageId;
            LastMessageCreateAt = lastMessageAt;
        }
        public void SetDeleted()
        {
            IsDeleted = true;
        }


        public void SetUnDeleted()
        {
            IsDeleted = false;
        }
        public void setCloseThread()
        {
            IsClosed = true;
        }
        public void OpenThread()
        {
            IsClosed = false;
        }




        public Guid ParticipantId;
        public ParticipantEntity Participant { get; set; }
    }
}