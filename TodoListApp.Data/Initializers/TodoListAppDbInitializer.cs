using System.Data.Entity;
using TodoListApp.Data.Contexts;
using TodoListApp.Entities;

namespace TodoListApp.Data.Initializers
{
    public class TodoListAppDbInitializer : DropCreateDatabaseAlways<TodoListAppDbContext>
    {
        protected override void Seed(TodoListAppDbContext context)
        {
            var testUser = new User()
            {
                Id = 1,
                FirstName = "John",
                Surname = "Doe",
                Email = "john.doe@test.ie",
                Login = "john.doe@test.ie",
                Phone = "083123456",
                ConfirmedEmail = false,
                ConfirmedPhone = false,
                Password = "AGZL25F4NcDiwxxHXiDIWUHtP8MirPv7lytoWoDHGd7CfwCU0cBsyIZLhUcZfygWHw==",
                SecurityStamp = "cdb7e70e-9ada-454b-8a27-2704c4682409"
            };

            context.Users.Add(testUser);

            base.Seed(context);
        }
    }
}
