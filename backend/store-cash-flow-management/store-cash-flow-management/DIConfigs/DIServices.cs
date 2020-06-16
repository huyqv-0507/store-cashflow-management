using Microsoft.Extensions.DependencyInjection;
using Services.IServices;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store_cash_flow_management.DIConfigs
{
    public class DIServices
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IStoreService, StoreService>();
        }
    }
}
