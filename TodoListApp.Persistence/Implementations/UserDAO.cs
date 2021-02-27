using Effort;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TodoListApp.Data.Contexts;
using TodoListApp.Entities;
using TodoListApp.Persistence.Contracts;

namespace TodoListApp.Persistence.Implementations
{
    public class UserDAO : IUserDAO
    {
        public bool Delete(User user)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                context.Users.Attach(user);

                context.Entry(user).State = EntityState.Deleted;

                return context.SaveChanges() > 1;
            }
        }

        public User FindByEmail(User user)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                return context.Users.SingleOrDefault(u => u.Email.ToLower().Equals(user.Email.ToLower()));
            }
        }

        public User FindById(User user)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                return context.Users.SingleOrDefault(u => u.Id == user.Id);
            }
        }

        public User FindByName(User user)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                return context.Users.SingleOrDefault(u => u.Login == user.Login);
            }
        }

        public bool Insert(User user)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                context.Users.Add(user);

                return context.SaveChanges() > 0;
            }
        }

        public List<User> List()
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                return context.Users.ToList();
            }
        }

        public bool Update(User user)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                context.Users.Attach(user);

                context.Entry(user).State = EntityState.Modified;

                return context.SaveChanges() > 0;
            }
        }
    }
}
