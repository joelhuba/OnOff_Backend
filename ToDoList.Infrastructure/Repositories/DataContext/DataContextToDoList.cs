using Microsoft.EntityFrameworkCore;
using ToDoList.Core.Entities;
using ToDoList.Core.Interfaces.Repositories.DataContext;
using ToDoList.Infrastructure.Helpers;


namespace ToDoList.Infrastructure.Repositories.DataContext
    {
        public class DataContextToDoList : DbContext, IDataContext
        {
            public DataContextToDoList(DbContextOptions<DataContextToDoList> options)
           : base(options)
            {
            Database.EnsureCreated();
            }

            public DbSet<UserEntity> Users { get; set; }
            public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var adminPassword = "12345";
            var (adminHashed, adminSalt) = PasswordHashHelper.HashPassword(adminPassword);

            var customerPassword = "12345";
            var (customerHashed, customerSalt) = PasswordHashHelper.HashPassword(customerPassword);
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    IdUser = 1,
                    Email = "admin@todolist.com",
                    FirstName = "Admin",
                    LastName = "System",
                    Rol = "Administrator",
                    Password = adminHashed,
                    PasswordSalt = adminSalt
                },
                new UserEntity
                {
                    IdUser = 2,
                    Email = "customer@todolist.com",
                    FirstName = "John",
                    LastName = "Doe",
                    Rol = "Customer",
                    Password = customerHashed,
                    PasswordSalt = customerSalt
                }
            );

            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity
                {
                    IdTask = 1,
                    Title = "Primera tarea del cliente",
                    Description = "Esta es una tarea de ejemplo asignada al usuario Customer.",
                    IsCompleted = false,
                    IdUser = 2 
                }
            );
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
                => base.SaveChangesAsync(cancellationToken);
        }
    }
