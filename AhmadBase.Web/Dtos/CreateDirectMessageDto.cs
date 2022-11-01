using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhmadBase.Web.Dtos
{
    public class CreateDirectMessageDto
    {
        public string SecoundUserId { get; set; }
        public string Body { get; set; }
        public bool IsReplay { get; set; }
        public string MessageId { get; set; }
    }


    public class CreateDirectsMessageResultDto
    {
        public string ThreadId { get; set; }
        public string MesssageId { get; set; }
    }
}
