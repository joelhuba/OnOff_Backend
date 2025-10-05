using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Core.Interfaces.BLL;

namespace ToDoList.Infrastructure.BLL
{
    public static  class BllServiceExtension
    {
        public static IServiceCollection AddBussinessLogicLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddTransient<ITasksBLL, TasksBLL>();
            services.AddTransient<IUsersBLL, UsersBLL>();
            services.AddTransient<IAuthBLL, AuthBLL>();
            return services;
        }
    }
}
