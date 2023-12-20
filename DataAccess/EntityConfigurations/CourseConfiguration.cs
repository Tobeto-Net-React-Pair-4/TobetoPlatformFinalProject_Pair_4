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

            builder.HasOne(c => c.Category).WithMany(cat => cat.Courses).HasForeignKey(c => c.CategoryId).IsRequired();

            builder.HasOne(b => b.Instructor).WithMany(i => i.Courses).HasForeignKey(c => c.InstructorId);

            builder.HasMany(b => b.Users).WithMany(u => u.Courses);

            //builder.HasMany(b => b.Users).WithMany(u => u.Courses).UsingEntity(UserCourse);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //  categorydeki tüm dataya default olarak bu where koşulunu uygula. where deletedDate is null. Data silinmemişse getir.
        }
    }
}
