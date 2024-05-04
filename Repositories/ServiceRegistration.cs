using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Abstract;
using Repositories.Concreate;
using Repositories.Context;
using Repositories.Services.Abstract;
using Repositories.Services.Concreate;

namespace Repositories
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepoistories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("NutriFridgeConnectionString")));
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IFoodMaterialsService, FoodMaterialService>();
            services.AddScoped<IMaterialsService, MaterialsService>();

            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IFoodMaterialRepository, FoodMaterialRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            return services;
        }
    }
}
