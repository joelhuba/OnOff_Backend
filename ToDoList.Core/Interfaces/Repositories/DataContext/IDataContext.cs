using Microsoft.EntityFrameworkCore;
using ToDoList.Core.Entities;

namespace ToDoList.Core.Interfaces.Repositories.DataContext
{
    public interface IDataContext
    {
        DbSet<UserEntity> Users { get; }
        DbSet<TaskEntity> Tasks { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
