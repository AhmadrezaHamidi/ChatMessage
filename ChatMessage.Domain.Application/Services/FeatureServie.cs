using ChatMesssage.Application.Contract.Common;
using ChatMesssage.Application.Contract.Dtos;
using ChatMesssage.Application.IServices;
using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Application.Services
{
    public class FeatureServie : IFeatureService
    {
        private readonly IFeatureRepository featureRepository;
        public FeatureServie(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }
       
        public async Task<ChatMesssageActionResult<FeatureDto>> Add(FeatureDto model)
        {
            var result = new ChatMesssageActionResult<FeatureDto>();

            var feature = Feature.CreateNew(model.Title, model.Description, model.SortOrder);
            var featureAfterInsert = await featureRepository.Add(feature);
            await featureRepository.UnitOfWork.SaveEntitiesAsync();

            model.Id = featureAfterInsert.Id.Value;

            result.IsSuccess = true;
            result.Data = model;
            return result;
        }

        public async Task<ChatMesssageActionResult<FeatureDto>> Delete(Guid featureId)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatMesssageActionResult<FeatureDto>> GetById(Guid id, Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatMesssageActionResult<FeatureDto>> GetList(GridQueryDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<ChatMesssageActionResult<FeatureDto>> Update(FeatureDto feature)
        {
            throw new NotImplementedException();
        }
    }
}
