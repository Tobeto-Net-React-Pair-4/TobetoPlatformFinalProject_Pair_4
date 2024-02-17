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
    public class CourseFavouritedByUserConfiguration : IEntityTypeConfiguration<CourseFavouritedByUser>
    {
        public void Configure(EntityTypeBuilder<CourseFavouritedByUser> builder)
        {
            builder.Ignore(uf => uf.Id);
            builder.ToTable("CourseFavouritedByUsers").HasKey(uf => new { uf.UserId, uf.CourseId });

            builder.Property(uf => uf.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(uf => uf.CourseId).HasColumnName("CourseId").IsRequired();

            builder.HasQueryFilter(uf => !uf.DeletedDate.HasValue);
        }
    }
}
