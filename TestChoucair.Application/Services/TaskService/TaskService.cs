using AutoMapper;
using TestChoucair.Application.Service;
using TestChoucair.Domain.Repository;
using TestChoucair.Application.Dto;
using TestChoucair.Domain.Model;
using Choucair.Application.Service;
using TestChoucair.Infrastructure.Repository;

namespace TestChoucair.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IUnitOfWork<TaskUser> _unitOfWork;
        private readonly IMapper _mapper;

        public TaskService(
            IUnitOfWork<TaskUser> unitOfWork,
            ITaskRepository taskRepository,
            IMapper mapper)
        {
            _taskRepository = taskRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TaskResponseDto> AddTaskAsync(TaskRequestDto taskRequest)
        {
            var taskUser = _mapper.Map<TaskUser>(taskRequest);
            var responseTask = await _taskRepository.AddAsync(taskUser);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<TaskResponseDto>(responseTask);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _unitOfWork.Repository.GetByIdAsync(id);
            if (task == null)
            {
                return false;
            }

            await _unitOfWork.Repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<TaskResponseDto>> GetAll()
        {
            var responseTasks = await _unitOfWork.Repository.GetAllAsync();
            return _mapper.Map<List<TaskResponseDto>>(responseTasks);
        }

        public async Task<TaskResponseDto> GetTaskById(int id)
        {
            var responseTask = await _unitOfWork.Repository.GetByIdAsync(id);
            return responseTask != null ? _mapper.Map<TaskResponseDto>(responseTask) : null;
        }

        public async Task<List<TaskResponseDto>> GetTasksByUser(int userId)
        {
            var responseTasks = await _taskRepository.GetTasksByUserId(userId);
            return _mapper.Map<List<TaskResponseDto>>(responseTasks);
        }

        public async Task<TaskResponseDto> UpdateTaskAsync(int taskId, TaskRequestDto taskRequestDto)
        {
            var taskUser = _mapper.Map<TaskUser>(taskRequestDto);
            taskUser.Id = taskId; // Ensure the ID is set correctly
            _unitOfWork.Repository.Update(taskUser);
            await _unitOfWork.SaveChangesAsync();
            var responseTask = await _unitOfWork.Repository.GetByIdAsync(taskUser.Id);
            return responseTask != null ? _mapper.Map<TaskResponseDto>(responseTask) : null;
        }
    }
}