using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using TestChoucair.Application.Dto;
using TestChoucair.Application.Service;
using TestChoucair.Presentation.BaseResponse;

namespace TestChoucair.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IValidator<SignUpRequestDto> _signUpValidator;
        private readonly IValidator<SignInRequestDto> _signInValidator;
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService,
            IValidator<SignInRequestDto> signInValidator,
            IValidator<SignUpRequestDto> signUpValidator) {
            _authService = authService;
            _signInValidator = signInValidator;
            _signUpValidator = signUpValidator;
        }
        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] SignInRequestDto signIn)
        {
            ValidationResult validationResult = _signInValidator.Validate(signIn);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var result = await _authService.SignIn(signIn);
            if (result == null)
                return NotFound(BaseResponseResult.CreateResponse<SignInResponseDto>(result, HttpStatusCode.NotFound, "Task not found"));

            return Ok(BaseResponseResult.CreateResponse(result, HttpStatusCode.OK, "Task get all successfully"));
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] SignUpRequestDto signUp)
        {
            ValidationResult validationResult = _signUpValidator.Validate(signUp);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            try{
                var result = await _authService.SignUp(signUp);
                if (result == null)
                    return NotFound(BaseResponseResult.CreateResponse<SignUpResponseDto>(result, HttpStatusCode.NotFound, "Task not found"));
    
                return Ok(BaseResponseResult.CreateResponse(result, HttpStatusCode.OK, "Task get all successfully"));

            }catch(Exception exp){
                return NotFound(BaseResponseResult.CreateResponse<SignUpResponseDto>(null, HttpStatusCode.NotFound, "Task not found"));
            }
           

        }
    }
}
