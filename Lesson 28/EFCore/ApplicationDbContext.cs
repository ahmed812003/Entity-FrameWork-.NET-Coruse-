//using EFCore.Configurations;
//using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder) =>
            optionBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=EfCore;Integrated Security=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostTag>().HasKey(p => new {p.PostId , p.TagId});
            modelBuilder.Entity<PostTag>().Property(p => p.AddedOn).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<PostTag>().HasOne(p => p.Tag).WithMany(p => p.PostTags).HasForeignKey(p => p.TagId);

            modelBuilder.Entity<PostTag>().HasOne(p => p.Post).WithMany(p => p.PostTags).HasForeignKey(p => p.PostId);
        }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}

public class Post
{
    public int PostId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public ICollection<PostTag> PostTags { get; set; }
}

public class Tag
{
    public int TagId { get; set; }

    public ICollection<PostTag> PostTags { get; set; }
}

public class PostTag
{
    public int PostId { get; set; }

    public int TagId { get; set; }

    public DateTime AddedOn { get; set; }

    public Post Post { get; set; }

    public Tag Tag { get; set; }
}