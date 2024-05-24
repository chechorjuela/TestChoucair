namespace TestChoucair.Domain.Model
{
    public class TaskUser : Entity<TaskUserId>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime Time { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}