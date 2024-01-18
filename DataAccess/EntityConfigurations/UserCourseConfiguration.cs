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
            builder.Ignore(uc => uc.Id);
            builder.ToTable("UserCourses").HasKey(uc => new {uc.CourseId, uc.UserId});

            builder.Property(uc => uc.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uc => uc.CourseId).HasColumnName("CourseId").IsRequired();


            builder.HasOne(uc => uc.Course).WithMany(c => c.UserCourses).HasForeignKey(uc => uc.CourseId);
            builder.HasOne(uc => uc.User).WithMany(c => c.UserCourses).HasForeignKey(uc => uc.UserId);

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        }
    }
}
