using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Mapster;
using MapsterMapper;
using ChatMesssage.Infrastructure.Mapping;
using MediatR;
using ChatMesssage.Infrastructure.Common;
using ChatMesssage.Infrastructure.FileStorage;
using ChatMesssage.Infrastructure.Repositories;
using ChatMesssage.Application.Common.Persistence;

namespace ChatMesssage.Infrastructure;

public static class Startup
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        MapsterSettings.Configure();
        return services
            .AddMediatR(Assembly.GetExecutingAssembly())
            .AddServices()
            .AddScoped(typeof(ChatMesssage.Domain.Core.SeedWork.Repository.IReadRepository<>), typeof(ApplicationDbRepository<>))
            .AddScoped(typeof(ChatMesssage.Domain.Core.SeedWork.Repository.IRepository<>), typeof(ApplicationDbRepository<>));
    }


    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder builder, IConfiguration config) =>
        builder
            .UseStaticFiles()
            .UseFileStorage();
}