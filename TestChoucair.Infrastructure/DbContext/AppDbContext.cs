using TestChoucair.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TestChoucair.Infrastructure.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskUser> Tasks { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(150);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(45);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(45);
                entity.Property(e => e.UserName).IsRequired().HasMaxLength(45);
                entity.Property(e => e.PasswordHash).IsRequired().HasMaxLength(150);
                entity.Property(e => e.CreateAt).IsRequired();
                entity.Property(e => e.UpdateAt).IsRequired(false);
            });

            modelBuilder.Entity<TaskUser>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Description).IsRequired();
                entity.Property(e => e.IsCompleted).IsRequired();
                entity.Property(e => e.UserId).IsRequired();

           
            });

        }
    }
}

