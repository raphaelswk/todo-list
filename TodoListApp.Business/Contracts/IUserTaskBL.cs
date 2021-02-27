using System.Collections.Generic;
using TodoListApp.Entities;

namespace TodoListApp.Business.Contracts
{
    public interface IUserTaskBL
    {
        bool Insert(UserTask userTask);
        bool CheckUnCheckTask(int id);
        bool Delete(int id);
        List<UserTask> ListByUserId(int id);
    }
}
