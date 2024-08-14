using AnonymousForumz.Models;
using BCrypt.Net; // Make sure to install BCrypt.Net package
using Microsoft.EntityFrameworkCore;

namespace AnonymousForumz
{
    public class UserService
    {
        private readonly QuizDbContext _context;
        private readonly CustomAuthenticationStateProvider _authenticationStateProvider;

        public UserService(QuizDbContext context, CustomAuthenticationStateProvider authenticationStateProvider)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authenticationStateProvider = authenticationStateProvider ?? throw new ArgumentNullException(nameof(authenticationStateProvider));
        }

        public async Task<bool> CreateUserAsync(string username, string password, string email)
        {
            // Check if user already exists
            if (await _context.Users.AnyAsync(u => u.Username == username))
            {
                return false; // User already exists
            }

            // Hash the password
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // Create new user
            var user = new User
            {
                Username = username,
                Password = hashedPassword, // Store hashed password
                Email = email
            };

            // Add user to the database and save changes
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ValidateUserAsync(string username, string password)
        {
            // Retrieve user by username
            var user = await _context.Users
                .SingleOrDefaultAsync(u => u.Username == username);

            // Check if user exists and password matches
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                return true;
            }

            return false;
        }
    }
}
