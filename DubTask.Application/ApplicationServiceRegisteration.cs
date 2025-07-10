using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Application
{
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            //services.AddAutoMapper();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            return services;
        }
    }
}
