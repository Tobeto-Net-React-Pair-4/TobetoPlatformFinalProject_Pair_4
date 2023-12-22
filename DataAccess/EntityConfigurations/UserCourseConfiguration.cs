using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace DataAccess.EntityConfigurations
{
    public class UserCourseConfiguration : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.Ignore(i => i.Id);
            builder.ToTable("UserCourses").HasKey(s => new {s.CourseId,s.UserId});

            builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(s => s.CourseId).HasColumnName("CourseId").IsRequired();

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

            builder.HasOne(s => s.Course).WithMany(c => c.UserCourses).HasForeignKey(c => c.CourseId);
            builder.HasOne(s => s.User).WithMany(c => c.UserCourses).HasForeignKey(c => c.UserId);

        }
    }
}
