using Effort;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TodoListApp.Data.Contexts;
using TodoListApp.Entities;
using TodoListApp.Persistence.Contracts;

namespace TodoListApp.Persistence.Implementations
{
    public class UserTaskDAO : IUserTaskDAO
    {
        public bool Delete(UserTask userTask)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                context.UserTasks.Attach(userTask);

                context.Entry(userTask).State = EntityState.Deleted;

                return context.SaveChanges() > 1;
            }
        }

        public UserTask FindById(int id)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                return context.UserTasks.SingleOrDefault(u => u.Id == id);
            }
        }

        public bool Insert(UserTask userTask)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                context.UserTasks.Add(userTask);

                return context.SaveChanges() > 0;
            }
        }

        public List<UserTask> ListByUserId(int userId)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                return context.UserTasks.Where(t => t.UserId == userId).ToList();
            }
        }

        public bool Update(UserTask userTask)
        {
            var connection = DbConnectionFactory.CreateTransient();
            using (var context = new TodoListAppDbContext(connection))
            {
                context.UserTasks.Attach(userTask);

                context.Entry(userTask).State = EntityState.Modified;

                return context.SaveChanges() > 0;
            }
        }
    }
}
