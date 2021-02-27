using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using TodoListApp.Entities;
using TodoListApp.Identity.Identities;
using TodoListApp.Identity.Mappers;
using TodoListApp.IoC.Containers;
using TodoListApp.Persistence.Contracts;

namespace TodoListApp.Identity.Stores
{
    public class TodoListAppUserStore : IUserStore<TodoListAppIdentityUser, int>, 
                                        IUserEmailStore<TodoListAppIdentityUser, int>, 
                                        IUserPasswordStore<TodoListAppIdentityUser, int>, 
                                        IUserPhoneNumberStore<TodoListAppIdentityUser, int>, 
                                        IUserSecurityStampStore<TodoListAppIdentityUser, int>, 
                                        IUserLockoutStore<TodoListAppIdentityUser, int>, 
                                        IUserTwoFactorStore<TodoListAppIdentityUser, int>
    {
        private readonly IUserDAO _userDAO;

        public TodoListAppUserStore()
        {
            this._userDAO = TodoListAppWindsorContainer.Resolve<IUserDAO>();
        }

        #region IUserStore

        public Task CreateAsync(TodoListAppIdentityUser user)
        {
            var User = IdentityMapper.Map<TodoListAppIdentityUser, User>(user);

            var result = this._userDAO.Insert(User);

            user.Id = User.Id;

            return Task.FromResult<bool>(result);
        }

        public Task DeleteAsync(TodoListAppIdentityUser user)
        {
            var User = IdentityMapper.Map<TodoListAppIdentityUser, User>(user);

            var result = this._userDAO.Delete(User);

            return Task.FromResult<bool>(result);
        }

        public Task<TodoListAppIdentityUser> FindByIdAsync(int userId)
        {
            var User = this._userDAO.FindById(new User { Id = userId });

            var user = IdentityMapper.Map<User, TodoListAppIdentityUser>(User);

            return Task.FromResult<TodoListAppIdentityUser>(user);
        }

        public Task<TodoListAppIdentityUser> FindByNameAsync(string userName)
        {
            var User = this._userDAO.FindByName(new User { Login = userName });

            var user = IdentityMapper.Map<User, TodoListAppIdentityUser>(User);

            return Task.FromResult<TodoListAppIdentityUser>(user);
        }

        public Task UpdateAsync(TodoListAppIdentityUser user)
        {
            var User = IdentityMapper.Map<TodoListAppIdentityUser, User>(user);

            var result = this._userDAO.Update(User);

            return Task.FromResult<bool>(result);
        }

        public void Dispose()
        {
        }

        #endregion

        #region IUserEmailStore

        public Task SetEmailAsync(TodoListAppIdentityUser user, string email)
        {
            user.Email = email;

            return Task.FromResult<int>(0);
        }

        public Task<string> GetEmailAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> GetEmailConfirmedAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult(user.ConfirmedEmail);
        }

        public Task SetEmailConfirmedAsync(TodoListAppIdentityUser user, bool confirmed)
        {
            user.ConfirmedEmail = confirmed;

            return Task.FromResult<int>(0);
        }

        public Task<TodoListAppIdentityUser> FindByEmailAsync(string email)
        {
            var User = this._userDAO.FindByEmail(new User { Email = email });

            var user = IdentityMapper.Map<User, TodoListAppIdentityUser>(User);

            return Task.FromResult(user);
        }

        #endregion

        #region IUserPhoneNumberStore

        public Task SetPhoneNumberAsync(TodoListAppIdentityUser user, string phoneNumber)
        {
            user.Phone = phoneNumber;

            return Task.FromResult<int>(0);
        }

        public Task<string> GetPhoneNumberAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult(user.Phone);
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult(user.ConfirmedPhone);
        }

        public Task SetPhoneNumberConfirmedAsync(TodoListAppIdentityUser user, bool confirmed)
        {
            user.ConfirmedPhone = confirmed;

            return Task.FromResult<int>(0);
        }

        #endregion

        #region IUserPasswordStore

        public Task SetPasswordHashAsync(TodoListAppIdentityUser user, string passwordHash)
        {
            user.Password = passwordHash;

            return Task.FromResult<int>(0);
        }

        public Task<string> GetPasswordHashAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult(user.Password);
        }

        public Task<bool> HasPasswordAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult(!string.IsNullOrWhiteSpace(user.Password));
        }

        #endregion

        #region IUserSecurityStampStore

        public Task SetSecurityStampAsync(TodoListAppIdentityUser user, string stamp)
        {
            user.SecurityStamp = stamp;

            return Task.FromResult<int>(0);
        }

        public Task<string> GetSecurityStampAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult(user.SecurityStamp);
        }

        #endregion

        #region IUserLockoutStore

        public Task<DateTimeOffset> GetLockoutEndDateAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult(DateTimeOffset.MinValue);
        }

        public Task SetLockoutEndDateAsync(TodoListAppIdentityUser user, DateTimeOffset lockoutEnd)
        {
            return Task.FromResult<int>(0);
        }

        public Task<int> IncrementAccessFailedCountAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult<int>(0);
        }

        public Task ResetAccessFailedCountAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult<int>(0);
        }

        public Task<int> GetAccessFailedCountAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult<int>(0);
        }

        public Task<bool> GetLockoutEnabledAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult<bool>(false);
        }

        public Task SetLockoutEnabledAsync(TodoListAppIdentityUser user, bool enabled)
        {
            return Task.FromResult<int>(0);
        }

        #endregion

        #region IUserTwoFactorStore

        public Task SetTwoFactorEnabledAsync(TodoListAppIdentityUser user, bool enabled)
        {
            return Task.FromResult<int>(0);
        }

        public Task<bool> GetTwoFactorEnabledAsync(TodoListAppIdentityUser user)
        {
            return Task.FromResult<bool>(true);
        }

        #endregion
    }
}
