using System.Collections.Generic;
using TodoListApp.Entities;

namespace TodoListApp.Persistence.Contracts
{
    public interface IUserTaskDAO
    {
        bool Insert(UserTask userTask);
        bool Update(UserTask userTask);
        bool Delete(UserTask userTask);
        UserTask FindById(int id);
        List<UserTask> ListByUserId(int id);
    }
}
