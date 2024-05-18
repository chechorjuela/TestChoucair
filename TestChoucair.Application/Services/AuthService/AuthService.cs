using TestChoucair.Infrastructure.Helpers;
using TestChoucair.Application.Dto;
using Microsoft.Extensions.Logging;
using AutoMapper;
using TestChoucair.Domain.Repository;
using TestChoucair.Domain.Model;


namespace TestChoucair.Application.Service
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;
        private readonly IAuthRepository _authRepository;
        private readonly JwtTokenService _jwtTokenService;
        public AuthService(
            IMapper mapper,
            JwtTokenService jwtTokenService,
            ILoggerFactory loggerFactory,
            IAuthRepository authRepository)
        {
            _logger = loggerFactory.CreateLogger<AuthService>();
            _mapper = mapper;
            _authRepository = authRepository;
            _jwtTokenService = jwtTokenService;

        }
        public async Task<SignInResponseDto> SignIn(SignInRequestDto signIn)
        {
            string token = "";
            var user = _mapper.Map<User>(signIn);
          
            var result = await _authRepository.SignIn(user, signIn.Password);
            if (result != null)
                token = _jwtTokenService.GenerateToken(result);

            SignInResponseDto responseDto = _mapper.Map<SignInResponseDto>(result);
            responseDto.Token = token;
            responseDto.UserName = user.UserName;
            responseDto.UserId = user.Id;
            return responseDto;

        }

        public async Task<SignUpResponseDto> SignUp(SignUpRequestDto signUp)
        {
            var user = _mapper.Map<User>(signUp);
            var result = await _authRepository.SignUp(user, signUp.Password);
            SignUpResponseDto response = new SignUpResponseDto()
            {
                Success = result != null ? true : false,
                Message = result != null ? "User Loggin" : "User cannot login"
            };

            return response;
        }

        public async Task<bool> SignOut(string token)
        {
            throw new ArgumentException();

        }

    }
}