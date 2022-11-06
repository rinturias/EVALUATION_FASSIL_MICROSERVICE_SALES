using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Sales.Infrastructure.EF.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Sales.Domain.Interfaces;
using System.Sales.Infrastructure.Repositories;
using System.Sales.Infrastructure.EF;
using System.Sales.Application;
using MassTransit;
using Microsoft.EntityFrameworkCore.Migrations;

namespace System.Sales.Infrastructure
{
    public static class Extensions
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
         
            services.AddMediatR(Assembly.GetExecutingAssembly());
            var connectionString = configuration.GetConnectionString("SalesDbConnectionString");

            services.AddDbContext<ReadDbContext>(context => context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context => context.UseSqlServer(connectionString));

          

            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //AddRabbitMq(services, configuration);

            return services;
        }

    }
}
