using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    internal class AppealConfiguration : IEntityTypeConfiguration<Appeal>
    {
        public void Configure(EntityTypeBuilder<Appeal> builder)
        {
            builder.ToTable("Appeals").HasKey(b => b.Id);


            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
            builder.Property(b => b.Form).HasColumnName("Form").IsRequired();
            builder.Property(b => b.File).HasColumnName("File").IsRequired();
            builder.Property(b => b.AppealStatus).HasColumnName("AppealStatus");
            builder.Property(b => b.FormStatus).HasColumnName("FormStatus");
            builder.Property(b => b.FileStatus).HasColumnName("FileStatus");

            builder.HasMany(b => b.Users);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
