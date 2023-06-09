﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugsManager.Middlewares
{
    public static class AddDbContextExtension
    {
        public static object Configuration { get; private set; }

        public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Contexts.DatabaseContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("BugsConn"))
            );

            return services;
        }
    }
}
