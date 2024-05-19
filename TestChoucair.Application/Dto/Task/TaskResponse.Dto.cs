using TestChoucair.Domain.Model;

namespace TestChoucair.Application.Dto
{
    public class TaskResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
