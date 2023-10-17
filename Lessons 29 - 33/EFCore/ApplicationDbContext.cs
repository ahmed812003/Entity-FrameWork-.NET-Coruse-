//using EFCore.Configurations;
//using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
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
            modelBuilder.Entity<Blog>().HasIndex(p => p.Url).IsUnique().HasDatabaseName("Index_Url").HasFilter("[Url] IS NOT NULL");

            //modelBuilder.Entity<Person>().HasIndex(p => new { p.FirstName, p.SecondName });
        }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Person> Persons { get; set; }

        //[Index(nameof(Url) , IsUnique = true)]
        public class Blog
        {
            public int BlogId { get; set; }

            public string Url { get; set; }

            public List<Post> Posts { get; set; }
        }

        public class Post
        {
            public int PostId { get; set;}

            public int BlogId { get; set; }

            public Blog Blog { get; set; }

        }

        //[Index(nameof(FirstName) , nameof(SecondName))]
        public class Person
        {
            public int Id { get; set; }

            public string FirstName { get; set; }

            public string SecondName { get; set; }

        }
    }
}

