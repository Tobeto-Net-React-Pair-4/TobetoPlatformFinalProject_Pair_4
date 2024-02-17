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
    public class CourseLiveContentConfiguraiton : IEntityTypeConfiguration<CourseLiveContent>
    {
        public void Configure(EntityTypeBuilder<CourseLiveContent> builder)
        {
            builder.Ignore(c => c.Id);
            builder.ToTable("CourseLiveContents").HasKey(c => new { c.CourseId, c.LiveContentId });

            builder.Property(c => c.CourseId).HasColumnName("CourseId").IsRequired();
            builder.Property(c => c.LiveContentId).HasColumnName("LiveContentId").IsRequired();

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}
