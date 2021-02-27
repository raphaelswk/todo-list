using System.Collections.Generic;

namespace TodoListApp.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string Surname { get; set; }
        
        public string Login { get; set; }
        
        public string Email { get; set; }
        
        public bool ConfirmedEmail { get; set; }
        
        public string Phone { get; set; }
        
        public bool ConfirmedPhone { get; set; }

        public string Password { get; set; }

        public string SecurityStamp { get; set; }
        
        public virtual ICollection<UserTask> UserTasks { get; set; }
    }
}
