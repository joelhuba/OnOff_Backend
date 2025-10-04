    using Microsoft.EntityFrameworkCore;
    using System;
    using ToDoList.Core.Entities;
    using ToDoList.Core.Interfaces.Repositories.DataContext;

    namespace ToDoList.Infrastructure.Repositories.DataContext
    {
        public class DataContext : DbContext, IDataContext
        {
            public DataContext(DbContextOptions<DataContext> options)
           : base(options)
            {
            }

            public DbSet<UserEntity> Users { get; set; }
            public DbSet<TaskEntity> Tasks { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
                => base.SaveChangesAsync(cancellationToken);
        }
    }
