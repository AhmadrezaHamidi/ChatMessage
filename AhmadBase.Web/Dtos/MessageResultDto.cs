using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadBase.Core.Dtos
{
    public class MessageResultDto
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public string ThreadId { get; set; }
        public string Body { get; set; }
        public string OwnerId { get; set; }
        public bool HasReplay { get; set; }
        public bool Seen { get; set; }
        public string ReplayMessageId { get; set; }

    }
}
