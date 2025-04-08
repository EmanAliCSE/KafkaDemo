using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Infrastructure.Messaging;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(
             this IServiceCollection services,
             IConfiguration configuration)
        {
            // Database Context
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<IIdentityService, IdentityService>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Repositories
            //services.AddScoped<IBookingRepository, BookingRepository>();
            //services.AddScoped<IEventRepository, EventRepository>();
            //services.AddScoped<IOutboxRepository, OutboxRepository>();
            //services.AddScoped<IProcessedMessageRepository, ProcessedMessageRepository>();

            // Services
            // services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped<IDomainEventDispatcher, DomainEventDispatcher>();

            // Kafka Messaging
            //services.Configure<KafkaProducerConfig>(configuration.GetSection("Kafka:Producer"));
            //services.Configure<KafkaConsumerConfig>(configuration.GetSection("Kafka:Consumer"));
            //services.AddSingleton<IMessageProducer, KafkaProducer>();

            return services;
        }
    }
}
