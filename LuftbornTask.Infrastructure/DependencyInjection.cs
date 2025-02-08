using LuftbornTask.Domain.Entities;
using LuftbornTask.Domain.Interfaces;
using LuftbornTask.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftbornTask.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IBaseRepository<Clinic>), typeof(BaseRepo<Clinic>));
            return services;
        }
    }
}
