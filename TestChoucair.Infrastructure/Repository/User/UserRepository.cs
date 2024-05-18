using TestChoucair.Domain.Repository;
using TestChoucair.Domain.Model;

namespace TestChoucair.Infrastructure.Repository{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext){

        }
        public void Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserExists(string email)
        {
            throw new NotImplementedException();
        }

        Task<User> IUserRepository.AddAsync(User taskDto)
        {
            throw new NotImplementedException();
        }
    }
}