using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestChoucair.Domain.Model;

namespace TestChoucair.Infrastructure.ConfigurationBuilder
{
    public sealed class RoleBuilder : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");
            builder.HasKey(x => x.Id);

            builder.HasData(Role.GetValues());

            builder.HasMany(x => x.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();
        }
    }
}