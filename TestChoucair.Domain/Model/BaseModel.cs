namespace TestChoucair.Domain.Model{
    public class BaseModel<T> : Entity<T> {
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime? UpdateAt { get; set; }
    }
}