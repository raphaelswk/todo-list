using System.Data.Common;
using System.Data.Entity;
using TodoListApp.Data.Configurations;
using TodoListApp.Data.Initializers;
using TodoListApp.Entities;

namespace TodoListApp.Data.Contexts
{
    public class TodoListAppDbContext : DbContext
    {
        public TodoListAppDbContext(DbConnection connection)
            : base("name=TodoListAppConnectionString")
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer(new TodoListAppDbInitializer());

        }

        //public TodoListAppDbContext(DbConnection connection)
        //    : base(connection, false)
        //{
        //    Database.SetInitializer(new TodoListAppDbInitializer());
        //}

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserTaskConfiguration());
        }
    }
}
