using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Infrastructure.BLL;
using ToDoList.Infrastructure.Repositories;
using ToDoList.Infrastructure.Services;

namespace ToDoList.Infrastructure.Ioc
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddToDoListDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddRepositories(configuration);
            services.AddBussinessLogicLayer(configuration);
            services.AddService();
            return services;
        }
    }
}
