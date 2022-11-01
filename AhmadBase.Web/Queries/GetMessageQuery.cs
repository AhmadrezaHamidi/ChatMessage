using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AhmadBase.Core.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using AhmadBase.Core.interfere.IReposetory;
using AhmadBase.Core.Types;
using AhmadBase.Inferastracter;
using AhmadBase.Inferastracter.Datas.Entities;
using Mapster;

namespace AhmadBase.web.Queries
{
    public class GetMessageQuery : IRequest<ServiceResult<MessageResultDto>>
    {
        public string Id { get; set; }

        public GetMessageQuery(string id)
        {
            Id = id;
        }
    }



    public class GetMessageQueryHandler : IRequestHandler<GetMessageQuery,ServiceResult<MessageResultDto>>
    {
        private readonly IUnitOfWork<AppDbContext> unitOfWork;

        public GetMessageQueryHandler(IUnitOfWork<AppDbContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<ServiceResult<MessageResultDto>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            var repo = unitOfWork.GetRepository<MessageEntity>();
            var message = repo.GetFirstOrDefault(predicate: x => x.Id.Equals(request.Id));
            var res = message.Adapt<MessageResultDto>();
        
            return ServiceResult.Create<MessageResultDto>(res);
        }
    }
}
