using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class HomeworkFileConfiguration : IEntityTypeConfiguration<HomeworkFile>
    {
        public void Configure(EntityTypeBuilder<HomeworkFile> builder)
        {
            builder.Ignore(h => h.Id);
            builder.ToTable("HomeworkFiles").HasKey(h => new { h.FileId, h.HomeworkId });

            builder.Property(h => h.FileId).HasColumnName("FileId").IsRequired();
            builder.Property(h => h.HomeworkId).HasColumnName("HomeworkId").IsRequired();

            builder.HasQueryFilter(h => !h.DeletedDate.HasValue);
        }
    }
}
