using TestChoucair.Domain.Model;

namespace TestChoucair.Domain.Repository{
    public interface IAuthRepository {
        Task<User> SignIn(User signIn, string password);
        Task<User> SignUp(User signUp, string password);
        Task<bool> SignOut(string token);    
    }
}