using TestChoucair.Domain.Model;

namespace TestChoucair.Domain.Repository{
    public interface ITaskRepository {
        Task<TaskUser> AddAsync(TaskUser taskDto);
        Task<List<TaskUser>> GetTasksByUserId(int userId);
    }
}