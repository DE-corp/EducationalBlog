﻿using EducationalBlog.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalBlog.Data.Context
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Article>().ToTable("Articles");
            builder.Entity<Tag>().ToTable("Tags");
            builder.Entity<Comment>().ToTable("Comments");

            builder.Entity<Comment>()
                .HasOne(a => a.User)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.User_Id)
                .HasPrincipalKey(d => d.Id)
                .IsRequired(false);
        }
    }
}
