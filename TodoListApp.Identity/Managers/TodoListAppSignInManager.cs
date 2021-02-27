using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using TodoListApp.Identity.Identities;

namespace TodoListApp.Identity.Managers
{
    public class TodoListAppSignInManager : SignInManager<TodoListAppIdentityUser, int>
    {
        public TodoListAppSignInManager(TodoListAppUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override async Task<ClaimsIdentity> CreateUserIdentityAsync(TodoListAppIdentityUser user)
        {
            var manager = (TodoListAppUserManager)UserManager;

            var identity = await manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

            return identity;
        }

        public static TodoListAppSignInManager Create(IdentityFactoryOptions<TodoListAppSignInManager> options, IOwinContext context)
        {
            return new TodoListAppSignInManager(context.GetUserManager<TodoListAppUserManager>(), context.Authentication);
        }
    }
}
