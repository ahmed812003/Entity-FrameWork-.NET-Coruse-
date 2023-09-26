using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Configurations
{
    public class AuthorEntityTypeConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {

        }

        public void FirstNameConfigure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(p => p.FirstName).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(50);
        }

        public void LastNameConfigure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(p => p.LastName).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50);
        }

        public void DisplyNameConfigure(EntityTypeBuilder<Author> builder) =>
            builder.Property(p => p.DisplyName).HasComputedColumnSql("[FirstName] + ', ' + [LastName]");

    }
}
