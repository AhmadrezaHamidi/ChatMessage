using ChatMesssage.Application.IServices;
using ChatMesssage.Application.Services;
using ChatMesssage.Domain.Core.AggregatesModel.FeatureAggregate;

namespace ChatMesssage.API.Configurations
{
    public static class ServicesSetup
    {
        public static void AddServicesSetup(this IServiceCollection services)
        {
            services.AddScoped<IFeatureService, FeatureServie>();
        }
    }
}
