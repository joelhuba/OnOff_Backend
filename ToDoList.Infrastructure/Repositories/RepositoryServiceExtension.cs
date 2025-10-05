using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Core.Interfaces.Repositories;
using ToDoList.Core.Interfaces.Repositories.DataContext;
using ToDoList.Infrastructure.Repositories.DataContext;

namespace ToDoList.Infrastructure.Repositories
{
    public static class RepositoryServiceExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddTransient<IDataContext, DataContextToDoList>();
            services.AddTransient<ITasksRepository, TasksRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            services.AddTransient<IAuthRepository, AuthRepository>();
            return services;
        }
    }
}
