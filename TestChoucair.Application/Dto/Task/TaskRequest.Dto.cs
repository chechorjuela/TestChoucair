namespace TestChoucair.Application.Dto
{
    public class TaskRequestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
    }
}