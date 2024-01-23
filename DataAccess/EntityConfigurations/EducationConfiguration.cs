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
    public class EducationConfiguration : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations").HasKey(b => b.Id);


            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.EducationalDegree).HasColumnName("EducationalDegree").IsRequired();
            builder.Property(b => b.University).HasColumnName("University").IsRequired();
            builder.Property(b => b.Department).HasColumnName("Department").IsRequired();
            builder.Property(b => b.StartOfYear).HasColumnName("StartOfYear").IsRequired();
            builder.Property(b => b.GraduationYear).HasColumnName("GraduationYear").IsRequired();
            builder.Property(b => b.Status).HasColumnName("Status").IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

            builder.HasOne(c => c.User).WithMany(u => u.Educations).HasForeignKey(c => c.UserId);

        }
    }
}

