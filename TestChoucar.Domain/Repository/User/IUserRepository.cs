using TestChoucair.Domain.Model;

namespace TestChoucair.Domain.Repository{
    public interface IUserRepository {
        Task<User> AddAsync(User taskDto);
    }
}