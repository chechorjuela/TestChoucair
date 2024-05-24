
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestChoucair.Domain.Enum;
using TestChoucair.Domain.Model;
using TestChoucair.Domain.Permissions;

namespace TestChoucair.Infrastructure.ConfigurationBuilder
{
    public sealed class RolePermissionBuilder : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolesPermissions");
            builder.HasKey(x => new { x.RoleId, x.PermissionId });


            builder.Property(x => x.PermissionId)
            .HasConversion(
                permissionId => permissionId!.Value,
                value => new Domain.Permissions.PermissionId(value)
            );

            builder.HasData(
                Create(Role.Client, PermissionEnum.ReadUser),
                Create(Role.Admin, PermissionEnum.WriteUser),
                Create(Role.Admin, PermissionEnum.UpdateUser),
                Create(Role.Admin, PermissionEnum.ReadUser)
            );
        }

        private static RolePermission Create(Role role, PermissionEnum permission)
        {
            return new RolePermission
            {
                RoleId = role.Id,
                PermissionId = new PermissionId((int)permission)
            };
        }

    }


}