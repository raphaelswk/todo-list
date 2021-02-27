using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using TodoListApp.Web.ViewModels;
using TodoListApp.Business.Contracts;
using TodoListApp.Business.Implementations;
using TodoListApp.Entities;

namespace TodoListApp.Web.Controllers
{
    [Authorize]
    public class UserTaskController : Controller
    {
        private readonly IUserTaskBL _userTaskBL;

        public UserTaskController()
        {
            this._userTaskBL = new UserTaskBL();
        }

        // GET: UserTask
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetData()
        {
            var userId = User.Identity.GetUserId<int>();

            var tasks = _userTaskBL.ListByUserId(userId);

            var tasksVM = new List<UserTaskViewModel>();

            foreach (var task in tasks)
            {
                tasksVM.Add(new UserTaskViewModel()
                {
                    Id = task.Id,
                    UserId = task.UserId,
                    Description = task.Description,
                    Checked = task.Checked,
                    CreatedAt = task.CreatedAt,
                    ModifiedAt = task.ModifiedAt
                });
            }

            return Json(new { isSucceeded = true, data = tasksVM }, JsonRequestBehavior.AllowGet);            
        }

        // POST: UserTask/Create
        [HttpPost]
        public JsonResult Create(string description)
        {
            var userId = User.Identity.GetUserId<int>();

            var result = _userTaskBL.Insert(new UserTask()
            {
                UserId = userId,
                Description = description
            });

            return Json(new { isSucceeded = result }, JsonRequestBehavior.AllowGet);
        }

        // POST: UserTask/ChangeState
        [HttpPost]
        public JsonResult ChangeState(int id)
        {
            var result = _userTaskBL.CheckUnCheckTask(id);

            return Json(new { isSucceeded = result }, JsonRequestBehavior.AllowGet);
        }

        // POST: UserTask/Delete
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var result = _userTaskBL.Delete(id);

            return Json(new { isSucceeded = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
