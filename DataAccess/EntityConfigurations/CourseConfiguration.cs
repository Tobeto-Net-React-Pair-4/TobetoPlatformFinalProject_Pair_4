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
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.ToTable("Courses").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CategoryId).HasColumnName("CategoryID").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Producer).HasColumnName("Producer").IsRequired();
            builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl");
            builder.Property(b => b.StartOfDate).HasColumnName("StartOfDate");
            builder.Property(b => b.EndOfDate).HasColumnName("EndOfDate");
            builder.Property(b => b.TimeOfSpent).HasColumnName("TimeOfSpent");
            builder.Property(b => b.EstimatedTime).HasColumnName("EstimatedTime");
            builder.Property(b => b.ContentCount).HasColumnName("ContentCount");
            builder.Property(b => b.Description).HasColumnName("Description");

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Courses_Name").IsUnique();

            builder.HasMany(c => c.Homeworks).WithOne(h => h.Course).HasForeignKey(h => h.CourseId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Assignments).WithOne(a => a.Course).HasForeignKey(a => a.CourseId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.CourseLikedByUsers).WithOne(uc => uc.Course).HasForeignKey(uc => uc.CourseId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.CourseAsyncContents).WithOne(ca => ca.Course).HasForeignKey(ca => ca.CourseId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.CourseLiveContents).WithOne(cl => cl.Course).HasForeignKey(cl => cl.CourseId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.Calendars).WithOne(c => c.Course).HasForeignKey(c => c.CourseId);
            builder.HasMany(c => c.CourseLikedByUsers).WithOne(clbu => clbu.Course).HasForeignKey(clbu => clbu.CourseId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

        }
    }
}
