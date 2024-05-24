using TestChoucair.Domain.Permissions;
using TestChoucair.Domain.Shared;

namespace TestChoucair.Domain.Model
{
    public sealed class Role : Enumeration<Role>
    {
        public static readonly Role Client = new(1, "Client");
        public static readonly Role Admin = new(2, "Admin");


        public Role(int id, string name) : base(id, name)
        {
        }

        public ICollection<Permission>? Permissions { get; set; }

    }
}