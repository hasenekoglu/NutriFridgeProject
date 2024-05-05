using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.Extensions;
using Repositories.Abstract;
using Repositories.Concreate;
using Repositories.Context;
using Repositories.Services.Abstract;
using Repositories.Services.Concreate;

namespace Repositories
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("NutriFridgeConnectionString")));
            services.AddScoped<IFoodService, FoodService>();
            services.AddScoped<IFoodMaterialsService, FoodMaterialService>();
            services.AddScoped<IMaterialsService, MaterialsService>();
            services.AddScoped<IChatService, ChatService>();

            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IFoodMaterialRepository, FoodMaterialRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IChatRepository, ChatRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();

            //services.AddOpenAIService(settings =>
            //    settings.ApiKey = "sk-proj-1q9a9ykVy37i3ANehfqCT3BlbkFJO5OGlm0qnkpDcXvTNAwx");

            return services;
        }
    }
}
