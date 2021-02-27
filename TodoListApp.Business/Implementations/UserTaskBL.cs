using System;
using System.Collections.Generic;
using TodoListApp.Business.Contracts;
using TodoListApp.Entities;
using TodoListApp.IoC.Containers;
using TodoListApp.Persistence.Contracts;

namespace TodoListApp.Business.Implementations
{
    public class UserTaskBL : IUserTaskBL
    {
        private readonly IUserTaskDAO _userTaskDAO;

        public UserTaskBL()
        {
            this._userTaskDAO = TodoListAppWindsorContainer.Resolve<IUserTaskDAO>();
        }

        public bool CheckUnCheckTask(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new ArgumentNullException("Id", "Task Id is Required");
                }

                var task = _userTaskDAO.FindById(id);

                task.Checked = !task.Checked;
                task.ModifiedAt = DateTime.Now;

                return _userTaskDAO.Update(task);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new ArgumentNullException("Id", "Task Id is Required");
                }

                var task = _userTaskDAO.FindById(id);

                if (task != null)
                {
                    return _userTaskDAO.Delete(task);
                }

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Insert(UserTask userTask)
        {
            try
            {
                if (userTask.UserId < 1)
                {
                    throw new ArgumentNullException("UserId", "User Id is Required");
                }

                if (string.IsNullOrEmpty(userTask.Description))
                {
                    throw new ArgumentNullException("Description", "Description is Required");
                }

                userTask.Checked = false;
                userTask.CreatedAt = DateTime.Now;
                userTask.ModifiedAt = DateTime.Now;

                return _userTaskDAO.Insert(userTask);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UserTask> ListByUserId(int userId)
        {
            try
            {
                if (userId < 1)
                {
                    throw new ArgumentNullException("Id", "User Id is Required");
                }

                return _userTaskDAO.ListByUserId(userId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
