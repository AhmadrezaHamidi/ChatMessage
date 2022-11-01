using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadBase.Inferastracter.Datas.Entities
{
    public class MessageEntity : EntityBase
    {
        public MessageEntity(string threadId, string body, string ownerId,
            bool hasReplay, bool seen, string replayMessageId)
        {
            Id = Guid.NewGuid();
            IsDeleted = false;
            CreatedAt = DateTime.Now;
            UpdatedAt = null;
            ThreadId = threadId;
            Body = body;
            OwnerId = ownerId;
            HasReplay = hasReplay;
            Seen = seen;
            ReplayMessageId = replayMessageId;
        }


        public string ThreadId { get; set; }
        public string Body { get; set; }
        public string OwnerId { get; set; }
        public bool HasReplay { get; set; }
        public bool Seen { get; set; }
        public string ReplayMessageId { get; set; }

        public void setCreatedAt()
        {
            CreatedAt = DateTime.Now;
        }

    }


    public enum ParticipantRoleEnum
    {
        Member,
        Creator,
        Admin
    }
}
