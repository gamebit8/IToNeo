using Autofac;
using Autofac.Extensions.DependencyInjection;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.Infrastructure.Data;
using IToNeo.Infrastructure.Identity;
using IToNeo.WebAPI.ApiEndpoints.V2.Equipments;
using IToNeo.WebAPI.Extensions;
using IToNeo.WebAPI.IntegrationEvents;
using IToNeo.WebAPI.Services.Automapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WebAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            //use in-memory database
            //ConfigureInMemoryDatabases(services);

            //// use real database
            ConfigureRealSqlDatabases(services);
        }


        private void ConfigureInMemoryDatabases(IServiceCollection services)
        {
            //use in-memory database
            services.AddDbContext<IToNeoContext>(c => c.UseInMemoryDatabase("IToNeoDB"));
            services.AddDbContext<IToNeoIdentityDbContext>(c => c.UseInMemoryDatabase("IToNeoIdentityDB"));

            ConfigureServices(services);
        }

        public void ConfigureRealSqlDatabases(IServiceCollection services)
        {
            // use real database
            services.AddDbContext<IToNeoContext>(c => c.UseNpgsql(Configuration.GetValue<string>("DBConnection")));
            services.AddDbContext<IToNeoIdentityDbContext>(c => c.UseNpgsql(Configuration.GetValue<string>("DBIdentityConnection")));

            ConfigureServices(services);
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            Environment.IsDevelopment();
            services.AddCustomIdentity()
                .AddCustomAuthentication()
                .AddMediatR(typeof(Startup))
                .AddCustomClaimsService()
                .AddCustomRedisCache(Configuration)
                .AddCustomCors()
                .AddCustomMvc()
                .AddCustomSwagger()
                .AddCustomControllers()
                .AddAutoMapper(typeof(MapperProfile))
                .AddCustomRepository()
                .AddCustomLogger()
                .AddCustomFileHelper(Configuration)
                .AddCustomEmailSender()
                .AddCustomChangeService()
                .AddCustomEventBus(Configuration)
                .AddCustomGraphQL(Environment.IsDevelopment());
         
            var container = new ContainerBuilder();
            container.Populate(services);

            return new AutofacServiceProvider(container.Build());
        }


        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "IToNeo");
            });
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();       
            app.UseWebSockets();
            app.UseGraphQLWebSockets<EquipmentSchema>();
            app.UseGraphQL<EquipmentSchema>();
            app.UseGraphQLGraphiQL();
            app.UseGraphQLAltair();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
             
            ConfigureEventBus(app);
        }

        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<NewUserRegistredIntegrationEvent, NewUserRegistredIntegrationEventHandler>();
        }
    }
}
