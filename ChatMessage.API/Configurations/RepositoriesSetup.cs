using ChatMesssage.Application.Common.Persistence;
using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;
using ChatMesssage.Infrastructure.Database.Context;
using ChatMesssage.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChatMesssage.API.Configurations
{
    public static class RepositoriesSetup
    {
        public static void AddRepositorySetup(this IServiceCollection services)
        {
          services.AddScoped<IFeatureRepository, FeatureRepositoy>();
        }
    }
}
