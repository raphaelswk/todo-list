using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using TodoListApp.Identity.Identities;
using TodoListApp.Identity.Services;
using TodoListApp.Identity.Stores;

namespace TodoListApp.Identity.Managers
{
    public class TodoListAppUserManager : UserManager<TodoListAppIdentityUser, int>
    {
        public TodoListAppUserManager(IUserStore<TodoListAppIdentityUser, int> store) 
            : base(store)
        {
        }

        public static TodoListAppUserManager Create(IdentityFactoryOptions<TodoListAppUserManager> options, IOwinContext context)
        {
            var manager = new TodoListAppUserManager(new TodoListAppUserStore());

            manager.UserValidator = new UserValidator<TodoListAppIdentityUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                //RequireNonLetterOrDigit = true,
                //RequireDigit = true,
                //RequireLowercase = true,
                //RequireUppercase = true
            };

            //manager.UserLockoutEnabledByDefault = false;
            //manager.SupportsUserLockout = false;

            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<TodoListAppIdentityUser, int>
            {
                MessageFormat = "Your security code is {0}"
            });

            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<TodoListAppIdentityUser, int>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<TodoListAppIdentityUser, int>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }
    }
}
