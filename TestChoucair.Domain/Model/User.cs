
namespace TestChoucair.Domain.Model
{
    public class User : Entity<UserId>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateAt { get; set; }
        public ICollection<TaskUser> Tasks { get; set; }
        public ICollection<Role>? Roles { get; set; }

    }

}