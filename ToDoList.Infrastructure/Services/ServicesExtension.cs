using Microsoft.Extensions.DependencyInjection;
using ToDoList.Core.Interfaces.Services;

namespace ToDoList.Infrastructure.Services
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
           services.AddTransient<ILogServices, LogServices>();
           return services;
        }
    }
}
