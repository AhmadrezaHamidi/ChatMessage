  using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
  using System.Reflection;
  using System.Threading.Tasks;
  using AhmadBase.Core.interfere.IReposetory;
  using AhmadBase.Core.Logic;
  using AhmadBase.Inferastracter;
  using Microsoft.EntityFrameworkCore;
  using MediatR;

namespace AhmadBase.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(opetions =>
                opetions.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            services.AddUnitOfWork<AppDbContext>();

            services.AddControllers();
            
            
            
            services.AddMediatR(typeof(Program).GetTypeInfo().Assembly);

            //services.AddMediatR(typeof(Startup));



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AhmadBase.Web", Version = "v1" });
            });


            //services.addMediator

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            IUnitOfWork<AppDbContext> unitOfWork)
        {


            unitOfWork.DbContext.Database.GetAppliedMigrations();
            unitOfWork.DbContext.Database.Migrate();



            MapsterDtosConfigurations
                .Instance
                .Initialize();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AhmadBase.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
