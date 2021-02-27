using Microsoft.AspNet.Identity;
using System;
using TodoListApp.Entities;

namespace TodoListApp.Identity.Identities
{
    public class TodoListAppIdentityUser : User, IUser<int>
    {
        public TodoListAppIdentityUser()
        {
        }

        public TodoListAppIdentityUser(string userName)
        {
            this.UserName = userName;
        }        

        public string UserName
        {
            get { return this.Login; }
            set { this.Login = value; }
        }
    }
}
