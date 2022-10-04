using BlazorSozluk.Api.Core.Application.Interfaces.Repositories;
using BlazorSozluk.Api.Infrastructure.Persistence.Context;
using BlazorSozluk.Api.Infrastructure.Persistence.Repositories;
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

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEntryCommentRepository, EntryCommentRepository>();
            services.AddScoped<IEmailConfirmationRepository, EmailConfirmationRepository>();

            return services;
        }
    }
}
