using TestChoucair.Application.Dto;

namespace Choucair.Application.Service{
    public interface ITaskService {
        Task<TaskResponseDto> AddTaskAsync(TaskRequestDto taskRequest);
        Task<List<TaskResponseDto>> GetAll();
        Task<TaskResponseDto> GetTaskById(int id);
        Task<List<TaskResponseDto>> GetTasksByUser(int userId);
        Task<bool> DeleteTaskAsync(int id);
        Task<TaskResponseDto> UpdateTaskAsync(int taskId, TaskRequestDto taskResponseDto);

    }
}