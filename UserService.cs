using System.Threading.Tasks;

namespace AnonymousForumz
{
    public class UserService
    {
        private readonly CustomAuthenticationStateProvider _authenticationStateProvider;

        public UserService(CustomAuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public Task<bool> CreateUserAsync(string username, string password)
        {
            return Task.FromResult(_authenticationStateProvider.CreateUser(username, password));
        }

        public Task<bool> ValidateUserAsync(string username, string password)
        {
            return Task.FromResult(_authenticationStateProvider.ValidateUser(username, password));
        }
    }
}
