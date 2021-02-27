using System;

namespace TodoListApp.Web.ViewModels
{
    public class UserTaskViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
