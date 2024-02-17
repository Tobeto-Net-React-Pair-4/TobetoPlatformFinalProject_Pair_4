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
    public class CourseAsyncContentConfiguration : IEntityTypeConfiguration<CourseAsyncContent>
    {
        public void Configure(EntityTypeBuilder<CourseAsyncContent> builder)
        {

            builder.Ignore(cac => cac.Id);
            builder.ToTable("CourseAsyncContents").HasKey(cac => new { cac.CourseId, cac.AsyncContentId });

            builder.Property(cac => cac.CourseId).HasColumnName("CourseId").IsRequired();
            builder.Property(cac => cac.AsyncContentId).HasColumnName("AsyncContentId").IsRequired();

            builder.HasQueryFilter(ca => !ca.DeletedDate.HasValue);
        }
    }
}
