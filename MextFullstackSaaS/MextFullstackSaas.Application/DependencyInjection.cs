using FluentValidation;
using MediatR;
using MextFullstackSaas.Application.Common.Behaviours;
using MextFullstackSaas.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MextFullstackSaas.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //tüm validator ekler.
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
           
            });

            return services;
        }
    }
}
