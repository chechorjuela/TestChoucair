
using TestChoucair.Domain.Repository;
using TestChoucair.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TestChoucair.Infrastructure.Repository
{
    public class AuthRepository : BaseRepository<User>, IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AuthRepository> _logger;

        public AuthRepository(AppDbContext dbContext, ILoggerFactory loggerFactory) : base(dbContext)
        {
            _context = dbContext;
            _logger = loggerFactory.CreateLogger<AuthRepository>();
        }

        public async Task<User> SignIn(User signIn, string password)
        {
            var user = await _context.Users.Where(u => u.Email == signIn.Email).FirstOrDefaultAsync();
            if (!BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return null;
            }
            return user;
        }

        public Task<bool> SignOut(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<User> SignUp(User signUp, string password)
        {
            try
            {
                signUp.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
                await _context.Users.AddAsync(signUp);
                await _context.SaveChangesAsync();
                return signUp;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw;
            }
        }

    }
}