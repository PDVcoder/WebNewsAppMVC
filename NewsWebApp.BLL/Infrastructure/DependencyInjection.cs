using Microsoft.Extensions.DependencyInjection;
using NewsWebApp.BLL.Interfaces;
using NewsWebApp.BLL.Services;
using NewsWebApp.DAL.EF;
using NewsWebApp.DAL.Interfaces;
using NewsWebApp.DAL.Reposiotories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebApp.BLL.Infrastructure
{
    public static class DependencyInjection 
    {
        //private static readonly IServiceCollection _services;
        public static IServiceCollection AddRepository(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUnitOfWork>(prov => new EFUnitOfWork(connectionString));
            return services;
        }
    }
}
