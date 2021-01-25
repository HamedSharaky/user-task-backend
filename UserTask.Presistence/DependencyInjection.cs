using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using UserTask.Application.Common.Interfaces;

namespace UserTask.Presistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserTaskDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("UserTaskConnectionString")));

            services.AddScoped<IUserTaskDbContext>(provider => provider.GetService<UserTaskDbContext>());

            return services;
        }
    }
}