namespace BaseAPI.DI
{
    using Application.IGenericRepository;

    using Application.IService;
    using Application.IUnitOfWork;
    using BaseAPI.Middleware.JWTMidlleware;
    using Domain.Config;
    using Domain.Entities;
    using Domain.Payload.Base;
    using Domain.Share.Common;
    using EmailService.Config;
    using EmailService.Implement;
    using EmailService.Interface;
    using Infrastructure.Context;
    using Infrastructure.GenericRepository;
    using Infrastructure.Service;
    using Infrastructure.UnitOfWork;
    using MassTransit;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Http;
    using Newtonsoft.Json;
    using RabbitMQContract.Config;
    using RabbitMQContract.Consumer;
    using RabbitMQContract.Consumer.Email;
    using Serilog;
    using Serilog.Events;
    using Serilog.Sinks.Discord;
    using System;
    using System.Text;

    public class DependencyInjection
    {
        public static void Register(IServiceCollection services, IConfiguration configuration, HttpContextAccessor contextAccessor)
        {
            #region Service Configuration
            services.AddScoped<IBaseService, BaseService>();
            #endregion

            #region Repository Configuration
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion

            #region Cache Configuration

            services.AddMemoryCache();
            services.AddScoped(typeof(GenericCacheInvalidator<>));

            #endregion

            #region Serilog Config
            services.AddSerilog();

            var webHookId = configuration["Discord:WebHookId"];
            var webHookToken = configuration["Discord:WebHookToken"];

            var hookId = configuration["DiscordChangeDataLog:HookID"];
            var hookToken = configuration["DiscordChangeDataLog:HookToken"];


            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()

            .WriteTo.Discord(
              webhookId: ulong.Parse(webHookId),
              webhookToken: webHookToken,
              restrictedToMinimumLevel: LogEventLevel.Error
            )

            .WriteTo.Logger(lc => lc
            .Filter.ByIncludingOnly(le =>
            le.Level == LogEventLevel.Information &&
            le.MessageTemplate.Text.Contains("🧑‍💻"))

              .WriteTo.Discord(
                  webhookId: ulong.Parse(hookId),
                  webhookToken: hookToken
              )
          )

          .CreateLogger();

            #endregion

            #region Database Configuration

            services.AddDbContext<DBContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<QueueDbContext>();

            #endregion

            #region Common Configuration
            #endregion

            #region Email Settings
            services.Configure<SendMailConfig>(configuration.GetSection("EmailSettings"));
            services.AddScoped<IEmailSender, EmailSender>();

            #endregion

            #region RabbitMQ
            services.Configure<RabbitMQConfig>(configuration.GetSection("RabbitMQ"));
            var rabbitSettings = configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();

                services.AddMassTransit(x =>
                {
                    x.AddConsumer<EmailConsumer>();
                    x.AddConsumer<EmailSendFileConsumer>();
                    x.AddConsumer<DbActionConsumer>();
                    x.AddConsumer<GenericQueueConsumer>();
                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(rabbitSettings.HostName, rabbitSettings.VirtualHost, h =>
                        {
                            h.Username(rabbitSettings.UserName);
                            h.Password(rabbitSettings.Password);
                        });

                        cfg.ReceiveEndpoint("email-queue", e =>
                        {
                            e.ConfigureConsumer<EmailConsumer>(context);
                        });

                        cfg.ReceiveEndpoint("email-send-file", e =>
                        {
                            e.ConfigureConsumer<EmailSendFileConsumer>(context);
                        });

                        cfg.ReceiveEndpoint("generic-queue", e =>
                        {
                            e.ConfigureConsumer<GenericQueueConsumer>(context);
                            e.PrefetchCount = 20;
                            e.ConcurrentMessageLimit = 10;
                        });

                    });
                });


            #endregion

            #region Background Service
            //services.AddHostedService<ProductBackgroundService>();
            //services.AddSingleton<GenericCacheInvalidator<Product>>();
            #endregion

            #region UNIT OF WORK
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            #endregion

        }
    }
}
