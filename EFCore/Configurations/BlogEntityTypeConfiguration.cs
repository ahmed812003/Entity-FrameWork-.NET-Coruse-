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
    public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder) =>
            builder.Property(p => p.Url).IsRequired();

        public void DefultValueOfRating(EntityTypeBuilder<Blog> builder) =>
            builder.Property(p => p.Rating).HasDefaultValue(2);

        public void DefultValueOfAddedOn(EntityTypeBuilder<Blog> builder) =>
            builder.Property(p => p.AddedOn).HasDefaultValueSql("GETDATE()");

    }
}
