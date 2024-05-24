using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestChoucair.Domain.Model;

namespace TestChoucair.Infrastructure.ConfigurationBuilder {
    public sealed class TaskUserBuilder : IEntityTypeConfiguration<TaskUser> {
        public void Configure(EntityTypeBuilder<TaskUser> builder){
            builder.ToTable("TaskUser");
            builder.HasKey(e => e.Id);
            
            builder.Property(t => t.Id)
                .HasConversion(taskUserId => taskUserId!.Value, value => new TaskUserId(value));

            builder.Property(e => e.Title).IsRequired();
            builder.Property(e => e.Description).IsRequired();
            builder.Property(e => e.IsCompleted).IsRequired();
            builder.Property(e => e.UserId).IsRequired();
            //builder.Property(e => e.CreateAt).IsRequired();
            //builder.Property(e => e.UpdateAt).IsRequired(false);

       
        }
    }
}