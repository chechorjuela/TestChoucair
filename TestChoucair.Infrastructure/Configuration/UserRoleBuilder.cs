
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestChoucair.Domain.Model;

namespace TestChoucair.Infrastructure.ConfigurationBuilder
{
    public sealed class UserRoleBuilder : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UsersRoles");
            builder.HasKey(x => new { x.RoleId, x.UserId });
            builder.Property(user => user.UserId)
                .HasConversion(userId => userId!.Value, value => new UserId(value));
        }
    }
}