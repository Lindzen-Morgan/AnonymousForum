using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnonymousForumz
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // For now, return an anonymous user
            return Task.FromResult(new AuthenticationState(_anonymous));
        }

        public Task SetUserAuthenticated(string username)
        {
            var identity = new ClaimsIdentity([new(ClaimTypes.Name, username)], "apiauth_type");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            return Task.CompletedTask;
        }

        public Task SetUserLoggedOut()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            return Task.CompletedTask;
        }

        // Example method for user validation (to be implemented)
        public bool ValidateUser(string username, string password)
        {
            ArgumentNullException.ThrowIfNull(username);

            ArgumentNullException.ThrowIfNull(password);
            // Implement user validation logic here
            return true;
        }
    }
}