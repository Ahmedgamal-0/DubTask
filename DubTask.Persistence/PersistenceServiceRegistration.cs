using DubTask.Application.Base;
using DubTask.Application.Repositories;
using DubTask.Persistence.DbContexts;
using DubTask.Persistence.Repositories.Base;
using DubTask.Persistence.Repositories.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskItemRepository, TaskItemRepository>();
            services.AddScoped<IUserRepository,UserRepository>();

            return services;
        }
    }
}
