using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestChoucair.Domain.Model;

namespace TestChoucair.Infrastructure.ConfigurationBuilder
{
    public sealed class UserBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(e => e.Id);
            builder.Property(u => u.Id)
               .HasConversion(userId => userId!.Value, value => new UserId(value));
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(45);
            builder.Property(e => e.UserName).IsRequired().HasMaxLength(45);
            builder.Property(e => e.PasswordHash).IsRequired().HasMaxLength(150);
            builder.Property(e => e.CreateAt).IsRequired();
            builder.Property(e => e.UpdateAt).IsRequired(false);
            builder.HasMany(x => x.Roles)
                .WithMany()
                .UsingEntity<UserRole>();

            // builder.HasMany(e => e.Tasks)
            //     .WithOne(t => t.User)
            //     .HasForeignKey(t => t.UserId)
            //     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}