using System;

namespace TodoListApp.Entities
{
    public class UserTask
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public virtual User User { get; set; }
    }
}
