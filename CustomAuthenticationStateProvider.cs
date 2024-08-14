using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;


namespace AnonymousForumz
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
        private static readonly List<User> Users = new();

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_anonymous));
        }

        public Task SetUserAuthenticated(string username)
        {
            var identity = new ClaimsIdentity(
                new[] { new Claim(ClaimTypes.Name, username) },
                "apiauth_type");

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

        public bool ValidateUser(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }

        public bool CreateUser(string username, string password)
        {
            if (Users.Any(u => u.Username == username))
                return false;

            Users.Add(new User { Username = username, Password = password });
            return true;
        }
    }

    public class User
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
