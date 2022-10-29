using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AhmadBase.Core.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;

namespace AhmadBase.Core.Queries
{
    public  class GetMessageQuery : IRequest<MessageResultDto>
    {
        public string Id { get; set; }

        public GetMessageQuery(string id)
        {
            Id = id;
        }
    }
}
