using ChatMesssage.Application.Contract.Common;
using ChatMesssage.Application.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Application.IServices
{
    public interface IFeatureService
    {
        Task<ChatMesssageActionResult<FeatureDto>> GetById(Guid id, Guid userId);
        Task<ChatMesssageActionResult<FeatureDto>> GetList(GridQueryDto model = null);
        Task<ChatMesssageActionResult<FeatureDto>> Add(FeatureDto feature);
        Task<ChatMesssageActionResult<FeatureDto>> Update(FeatureDto feature);
        Task<ChatMesssageActionResult<FeatureDto>> Delete(Guid featureId);

    }
}
