using System.Collections.Generic;
using TodoListApp.Entities;

namespace TodoListApp.Persistence.Contracts
{
    public interface IUserDAO
    {
        bool Insert(User user);
        bool Update(User user);
        bool Delete(User user);
        User FindById(User user);
        User FindByName(User user);
        User FindByEmail(User user);
        List<User> List();
    }
}
