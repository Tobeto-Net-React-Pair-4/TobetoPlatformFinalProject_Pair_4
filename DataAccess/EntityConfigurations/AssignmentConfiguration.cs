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
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.ToTable("Assignments").HasKey(a => a.Id);
            builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
            builder.Property(a => a.CourseId).HasColumnName("CourseId").IsRequired();
            builder.Property(a => a.Name).HasColumnName("Name").IsRequired();
            builder.Property(a => a.Title).HasColumnName("Title").IsRequired();
            builder.Property(a => a.Status).HasColumnName("Status").IsRequired();
            builder.Property(a => a.Description).HasColumnName("Description").IsRequired();
            builder.Property(a => a.AssignmentType).HasColumnName("AssignmentType ").IsRequired();
            builder.Property(a => a.VideoUrl).HasColumnName("VideoUrl ").IsRequired();

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
            builder.HasMany(a => a.Files).WithOne(f => f.Assignment).HasForeignKey(f => f.AssignmentId);



        }
    }
}
