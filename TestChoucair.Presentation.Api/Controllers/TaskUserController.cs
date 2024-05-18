using Choucair.Application.Service;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TestChoucair.Application.Dto;
using TestChoucair.Presentation.BaseResponse;

namespace TestChoucair.Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskUserController : ControllerBase
    {
        private readonly IValidator<TaskRequestDto> _taskValidator;
        private readonly ITaskService _taskService;

        public TaskUserController(
            ITaskService taskService,
            IValidator<TaskRequestDto> taskValidator
            )
        {
            _taskService = taskService;
            _taskValidator = taskValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _taskService.GetAll();
            if (result == null)
                return NotFound(BaseResponseResult.CreateResponse<List<TaskResponseDto>>(result, HttpStatusCode.NotFound, "Task not found"));

            return Ok(BaseResponseResult.CreateResponse(result, HttpStatusCode.OK, "Task get all successfully"));

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TaskRequestDto taskRequest)
        {

            var result = await _taskService.AddTaskAsync(taskRequest);
            if (result == null)
                return NotFound(BaseResponseResult.CreateResponse<bool>(false, HttpStatusCode.NotFound, "Task not found"));

            return Ok(BaseResponseResult.CreateResponse(result, HttpStatusCode.OK, "Task create successfully"));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TaskRequestDto taskRequest)
        {
            ValidationResult validationResult = _taskValidator.Validate(taskRequest);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var result = await _taskService.UpdateTaskAsync(id, taskRequest);
            if (result == null)
                return NotFound(BaseResponseResult.CreateResponse<bool>(false, HttpStatusCode.NotFound, "Task not found"));

            return Ok(BaseResponseResult.CreateResponse(result, HttpStatusCode.OK, "Task update successfully"));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {

            var result = await _taskService.GetTaskById(id);
            if (result == null)
                return NotFound(BaseResponseResult.CreateResponse<TaskResponseDto>(null, HttpStatusCode.NotFound, "Task not found"));

            return Ok(BaseResponseResult.CreateResponse(result, HttpStatusCode.OK, "Task get by id task successfully"));

        }

        [HttpGet("getByUser/{userId}")]
        public async Task<IActionResult> getByUser([FromRoute] int userId)
        {
            var result = await _taskService.GetTasksByUser(userId);
            if (result == null)
                return NotFound(BaseResponseResult.CreateResponse<bool>(false, HttpStatusCode.NotFound, "Task not found"));

            return Ok(BaseResponseResult.CreateResponse(result, HttpStatusCode.OK, "Task Get by user Id successfully"));

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _taskService.DeleteTaskAsync(id);
            if (!result)
                return NotFound(BaseResponseResult.CreateResponse<bool>(false, HttpStatusCode.NotFound, "Task not found"));

            return Ok(BaseResponseResult.CreateResponse(result, HttpStatusCode.OK, "Task deleted successfully"));
        }
    }
}
