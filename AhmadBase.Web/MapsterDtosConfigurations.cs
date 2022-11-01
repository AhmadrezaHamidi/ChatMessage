using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhmadBase.Core.Dtos;
using AhmadBase.Inferastracter.Datas.Entities;
using AhmadBase.Web.Commands;
using AhmadBase.Web.Dtos;
using Mapster;

namespace AhmadBase.Web
{
    public class MapsterDtosConfigurations
    {
        static MapsterDtosConfigurations _instance;

        public static MapsterDtosConfigurations Instance =>
            _instance ?? (_instance = new MapsterDtosConfigurations());

        public void Initialize()
        {
            ConfigFor_CreateCommentDto_CommentEntity();
            ConfigFor_CreateDirectMessageDto_CreateDirectMessageCommand();
        }

        private MapsterDtosConfigurations ConfigFor_CreateCommentDto_CommentEntity()
        {
            TypeAdapterConfig<MessageEntity, MessageResultDto>
                .NewConfig()
                .Map(x => x.Id, x => x.Id)
                .Map(x => x.CreatedAt, x => x.CreatedAt)
                .Map(x => x.UpdatedAt, x => x.UpdatedAt)
                .Map(x => x.IsDeleted, x => x.IsDeleted)
                .Map(x => x.ThreadId, x => x.ThreadId)
                .Map(x => x.Body, x => x.Body)
                .Map(x => x.OwnerId, x => x.OwnerId)
                .Map(x => x.HasReplay, x => x.HasReplay)
                .Map(x => x.Seen, x => x.Seen)
                .Map(x => x.ReplayMessageId, x => x.ReplayMessageId)
                ;
            return this;
        }




        private MapsterDtosConfigurations ConfigFor_CreateDirectMessageDto_CreateDirectMessageCommand()
        {
            TypeAdapterConfig<CreateDirectMessageDto, CreateDirectMessageCommand>
                .NewConfig()
                .Ignore(x => x.FirstUserId)
                .Map(x => x.SecundUserId, x => x.SecoundUserId)
                .Map(x => x.Body, x => x.Body)
                .Map(x => x.isReplay, x => x.IsReplay)
                .Map(x => x.MessageId, x => x.MessageId)
                .Map(x => x.Body, x => x.Body)
                ;
            return this;
        }








    }
}