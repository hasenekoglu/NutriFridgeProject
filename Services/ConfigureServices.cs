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
using Services.Abstract;
using Services.Concreate;

namespace Services
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("NutriFridgeConnectionString")));
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IFoodMaterialsService, FoodMaterialService>();
            services.AddScoped<IMaterialsService, MaterialsService>();
            return services;
        }
    }
}
