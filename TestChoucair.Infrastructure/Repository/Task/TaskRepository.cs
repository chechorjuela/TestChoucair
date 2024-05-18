using TestChoucair.Domain.Repository;
using TestChoucair.Domain.Model;

namespace TestChoucair.Infrastructure.Repository
{
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        private readonly AppDbContext _context;
        public TaskRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TaskUser> AddAsync(TaskUser task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<List<TaskUser>> GetTasksByUserId(int userId)
        {
            // var tasks = _context.Tasks.Where( f => userId == f.UserId).ToList();
            return null;
        }
    }
}