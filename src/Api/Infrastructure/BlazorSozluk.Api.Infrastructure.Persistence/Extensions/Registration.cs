using BlazorSozluk.Api.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorSozluk.Api.Infrastructure.Persistence.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlazorSozlukDbContext>(config =>
            {
                //var connStr = configuration["BlazorSozlukDbConnectionString"].ToString(); 
                //conf.UseSqlServer(connStr, opt =>
                //{
                //     opt.EnableRetryOnFailure(); 
                // });
                config.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            //var seedData = new SeedData();
            //seedData.SeedAsync(configuration).GetAwaiter().GetResult();

            //Bogus ile data oluşturmak için kullanıyor. bir sefer çalışması yeterli.

            return services;
        }
    }
}
