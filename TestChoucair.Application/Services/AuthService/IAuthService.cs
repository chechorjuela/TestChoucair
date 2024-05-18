using TestChoucair.Application.Dto;

namespace TestChoucair.Application.Service{
    public interface IAuthService {
        Task<SignInResponseDto> SignIn(SignInRequestDto signIn);
        Task<SignUpResponseDto> SignUp(SignUpRequestDto signUp);
        Task<bool> SignOut(string token);

    }
}