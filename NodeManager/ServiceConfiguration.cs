using FogEnvironment.NodeManager.Abstraction;
using FogEnvironment.NodeManager.BaseServices;
using FogEnvironment.NodeManager.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace FogEnvironment.NodeManager
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection SeviceRegistration(this IServiceCollection services) 
        {
            services.AddScoped<INodeDecorator, NodeDecorator>();
            services.AddScoped<ITaskManager, TaskManager>();
            services.AddScoped<IFitnessService, FitnessService>();

            services.AddSingleton<IAppSettings,AppSettings>();

            return services;    
        }
    }
}
