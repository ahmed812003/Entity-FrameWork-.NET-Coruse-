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

            modelBuilder.Entity<Blog>().HasOne(b => b.BlogImage).WithOne(b => b.Blog).HasForeignKey<BlogImage>(b => b.BlogId);
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BlogImage> BlogImages { get; set; }


    }
}

public class Blog
{
    public int Id { get; set; }

    public string Url { get; set; }

    public BlogImage BlogImage { get; set; }

}

public class BlogImage
{
    public int Id { get; set; }

    public string Image { get; set; }

    [Required,MaxLength(250)]
    public string Caption { get; set; }

    public int BlogId { get; set; }

    public Blog Blog { get; set; }
}