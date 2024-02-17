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
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.ToTable("Homeworks").HasKey(h => h.Id);

            builder.Property(h => h.Id).HasColumnName("Id").IsRequired();
            builder.Property(h => h.CourseId).HasColumnName("CourseId").IsRequired();
            builder.Property(h => h.LiveContentId).HasColumnName("CourseId").IsRequired();
            builder.Property(h => h.Name).HasColumnName("Name");
            builder.Property(h => h.SendStatus).HasColumnName("SendStatus");
            builder.Property(h => h.EndOfDate).HasColumnName("EndOfDate").IsRequired();
            builder.Property(h => h.InstructorDescription).HasColumnName("InstructorDescription");
            builder.Property(h => h.StudentDescription).HasColumnName("StudentDescription");

            builder.HasQueryFilter(h => !h.DeletedDate.HasValue);

            builder.HasMany(h => h.HomeworkFiles).WithOne(hm => hm.Homework).HasForeignKey(hm => hm.HomeworkId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
