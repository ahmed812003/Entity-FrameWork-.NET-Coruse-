using EFCore.Configurations;
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
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());

            modelBuilder.Entity<Blog>().HasMany(b => b.Posts).WithOne(b => b.Blog);
        }

        public DbSet<Blog> Blogs { get; set; }

    }
}

public class Blog
{
    public int Id { get; set; }

    public string Url { get; set; }

    public List<Post> Posts { get; set; }

}

public class Post
{
    public int PostId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public int BlogId { get; set; }

    public Blog Blog { get; set; }
}