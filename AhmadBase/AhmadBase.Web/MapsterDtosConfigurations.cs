using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhmadBase.Web
{
    public class MapsterDtosConfigurations
    {
        static MapsterDtosConfigurations _instance;

        public static MapsterDtosConfigurations Instance =>
            _instance ?? (_instance = new MapsterDtosConfigurations());

        public void Initialize()
        {
           /// ConfigFor_CreateCommentDto_CommentEntity();
        }

        //private AppplicationDtosConfigurations ConfigFor_CreateCommentDto_CommentEntity()
        //{
        //    TypeAdapterConfig<RegisterUserDto, CreateUserCommand>
        //        .NewConfig()
        //        .Map(x => x.FirstName, x => x.FirstName)
        //        .Map(x => x.LastName, x => x.LastName)
        //        .Map(x => x.NationaCode, x => x.NationaCode)
        //        .Map(x => x.PassWord, x => x.PassWord);
        //    return this;
        //}
    }
}