using TestChoucair.Domain.Permissions;

namespace TestChoucair.Domain.Model
{
    public sealed class RolePermission
    {
        public int RoleId { get; set; }
        public PermissionId? PermissionId { get; set; }
    }
}