using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace TodoListApp.Identity.Services
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            return Task.FromResult(0);
        }
    }
}
