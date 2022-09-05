using Autofac;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Instrumentation;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using IToNeo.ApplicationCore.Constants;
using IToNeo.ApplicationCore.Interfaces;
using IToNeo.Infrastructure.Data;
using IToNeo.Infrastructure.EmailSender;
using IToNeo.Infrastructure.EventBus;
using IToNeo.Infrastructure.Identity;
using IToNeo.Infrastructure.Identity.Entities;
using IToNeo.Infrastructure.Logging;
using IToNeo.WebAPI.ApiEndpoints.V1.Files;
using IToNeo.WebAPI.ApiEndpoints.V2.Equipments;
using IToNeo.WebAPI.IntegrationEvents;
using IToNeo.WebAPI.Interfaces;
using IToNeo.WebAPI.Services.CacheService;
using IToNeo.WebAPI.Services.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RabbitMQ.Client;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI;

namespace IToNeo.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                    .AddRoles<ApplicationRole>()
                    .AddEntityFrameworkStores<IToNeoIdentityDbContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                //options.User.RequireUniqueEmail = true;
            });

            return services;
        }

        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.SaveToken = true;
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = AuthorizationConstants.ISSUER,
                       ValidateAudience = true,
                       ValidAudience = AuthorizationConstants.AUDIENCE,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthorizationConstants.JWT_SECRET_KEY)),
                       RoleClaimType = ClaimTypes.Role,
                       NameClaimType = ClaimTypes.Name
                   };
               });

            return services;
        }

        public static IServiceCollection AddCustomClaimsService(this IServiceCollection services)
        {
            services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();

            return services;
        }

        public static IServiceCollection AddCustomRedisCache(
            this IServiceCollection services, IConfiguration configuration)
        {
            var redisCache = configuration.GetSection(RedisCacheServiceConfiguration.RedisCache).Get<RedisCacheServiceConfiguration>();

            if (redisCache.IsEnable)
            {
                services.AddStackExchangeRedisCache(options =>
                {
                    options.InstanceName = redisCache.InstanceName;
                    options.Configuration = redisCache.ServerAddress;
                });

                services.AddScoped(typeof(ICacheService<>), typeof(CacheService<>));
            }
            else
            {
                services.AddScoped(typeof(ICacheService<>), typeof(DummyCacheService<>));
            }

            return services;
        }

        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                        builder.WithExposedHeaders("Content-Disposition");
                    });
            });

            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddMvcCore().AddApiExplorer();

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IToNeo", Version = "v1" });
                c.EnableAnnotations();
            });

            return services;
        }

        public static IServiceCollection AddCustomControllers(this IServiceCollection services)
        {

            services.AddControllers().AddJsonOptions(options =>
                options.JsonSerializerOptions.WriteIndented = true
            );

            return services;
        }

        public static IServiceCollection AddCustomRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadOnlyAsyncRepository<>), typeof(EfReadOnlyRepository<>));

            return services;
        }

        public static IServiceCollection AddCustomLogger(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }

        public static IServiceCollection AddCustomFileHelper(
            this IServiceCollection services, IConfiguration configuration)
        {
            var fileConfiguration = configuration.GetSection(FilesServiceConfiguration.File).Get<FilesServiceConfiguration>();
            
            services.AddScoped<IFileHelper>(sp =>
            {
                return new FileHelper(fileConfiguration.MaximumFileSize, fileConfiguration.AllowedFileFormat);
            });

            return services;
        }

        public static IServiceCollection AddCustomEmailSender(this IServiceCollection services)
        {
            services.AddScoped<IEmailSender, EmailSender>();

            return services;
        }

        public static IServiceCollection AddCustomChangeService(this IServiceCollection services)
        {
            services.AddSingleton<IChangeService, EquipmentChangeService>();

            return services;
        }

        public static IServiceCollection AddCustomEventBus(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddTransient<NewUserRegistredIntegrationEventHandler>();

            var eventBusConfiguration = configuration.GetSection(EventBusServiceConfiguration.EventBus).Get<EventBusServiceConfiguration>();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<IAppLogger<DefaultRabbitMQPersistentConnection>>();
                var factory = new ConnectionFactory()
                {
                    HostName = eventBusConfiguration.Connection,
                    DispatchConsumersAsync = true,
                };

                if (!string.IsNullOrEmpty(eventBusConfiguration.UserName))
                {
                    factory.UserName = eventBusConfiguration.UserName;
                };

                if (!string.IsNullOrEmpty(eventBusConfiguration.Password))
                {
                    factory.UserName = eventBusConfiguration.Password;
                };

                var retryCount = 5;
                if (eventBusConfiguration.RetryCount != 0)
                {
                    retryCount = eventBusConfiguration.RetryCount;
                };

                return new DefaultRabbitMQPersistentConnection(factory, logger, retryCount);
            });


            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var subscriptionClientName = eventBusConfiguration.SubscriptionClientName;
                var iLifetimeScope = sp.GetRequiredService<ILifetimeScope>();
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var logger = sp.GetRequiredService<IAppLogger<EventBusRabbitMQ>>();
                var eventBusSubcriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (eventBusConfiguration.RetryCount != 0)
                {
                    retryCount = eventBusConfiguration.RetryCount;
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, logger, iLifetimeScope, eventBusSubcriptionsManager, subscriptionClientName, retryCount);
            });

            return services;
        }

        public static IServiceCollection AddCustomGraphQL(this IServiceCollection services, bool enveromentIsDevelopment)
        {
            services.AddGraphQL(services => services
                .AddDocumentExecuter<ApolloTracingDocumentExecuter>()
                .AddHttpMiddleware<EquipmentSchema>()
                .AddWebSocketsHttpMiddleware<EquipmentSchema>()
                .AddSchema<EquipmentSchema>()
                .ConfigureExecutionOptions(options =>
                {
                    options.EnableMetrics = enveromentIsDevelopment;
                    var logger = options.RequestServices.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx =>
                    {
                        logger.LogError("{Error} occurred", ctx.OriginalException.Message);
                        return Task.CompletedTask;
                    };
                })
                .AddSystemTextJson()
                .AddErrorInfoProvider<ErrorInfoProvider>()
                .AddWebSockets()
                .AddGraphQLAuthorization(o => o.AddPolicy("GraphQLRW", p => p.RequireClaim(ClaimTypes.Role, UserRoleConstants.ADMINISTATOR)))
                .AddUserContextBuilder(context => new GraphQLUserContext { User = context.User })
                .AddGraphTypes(typeof(EquipmentSchema).Assembly));

            return services;
        }
    }
}









