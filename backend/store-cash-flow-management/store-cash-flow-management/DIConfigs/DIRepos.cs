using Data.Infrastructures;
using Data.Infrastructures.IRepositories;
using Data.Infrastructures.Repositories;
using Data.Models;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store_cash_flow_management.DIConfigs
{
    public class DIRepos
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}
