using EFCore.Configurations;
using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            modelBuilder.Entity<AuditEntry>();
            new EmployeeEntityTypeConfiguration().Configure(modelBuilder.Entity<Employee>());
            new BlogEntityTypeConfiguration().Configure(modelBuilder.Entity<Blog>());
            new BlogEntityTypeConfiguration().DefultValueOfAddedOn(modelBuilder.Entity<Blog>());
            modelBuilder.Ignore<Post>();
            modelBuilder.Entity<Blog>().ToTable("Blogs", b => b.ExcludeFromMigrations());
            modelBuilder.Entity<Post>().ToTable("Posts");
            modelBuilder.Entity<Post>().ToTable("Posts", schema: "blogging");
            modelBuilder.HasDefaultSchema("blogging");
            modelBuilder.Entity<Blog>().Ignore(b => b.AddedOn);
            modelBuilder.Entity<Blog>().Property(p => p.Url).HasColumnName("BlogUrl");
            modelBuilder.Entity<Blog>(eb =>
            {
                eb.Property(p => p.Url).HasColumnType("varchar(200)");
                eb.Property(p => p.Rating).HasColumnType("decimal(5,2)");
                eb.Property(b => b.Url).HasColumnType("nvarchar(max)");
                eb.Property(b => b.Url).HasMaxLength(200);
                eb.Property(b => b.Url).HasComment("The Url of Blog");
            }); 
            modelBuilder.Entity<Book>().HasKey(p => p.Id).HasName("PK_BooksId");
            new BlogEntityTypeConfiguration().DefultValueOfAddedOn(modelBuilder.Entity<Blog>());
            new BlogEntityTypeConfiguration().DefultValueOfRating(modelBuilder.Entity<Blog>());
            new AuthorEntityTypeConfiguration().FirstNameConfigure(modelBuilder.Entity<Author>());
            new AuthorEntityTypeConfiguration().LastNameConfigure(modelBuilder.Entity<Author>());
            new AuthorEntityTypeConfiguration().DisplyNameConfigure(modelBuilder.Entity<Author>());
            new CategoryEntityTypeConfiguration().IdConfigure(modelBuilder.Entity<Category>());
            new CategoryEntityTypeConfiguration().NameConfigure(modelBuilder.Entity<Category>());
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Blog> Blogs { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
