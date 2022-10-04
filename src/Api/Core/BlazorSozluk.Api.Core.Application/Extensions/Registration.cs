using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Core.Application.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assmbly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assmbly);
            services.AddValidatorsFromAssembly(assmbly);
            services.AddMediatR(assmbly);

            return services;
        }
    }
}
