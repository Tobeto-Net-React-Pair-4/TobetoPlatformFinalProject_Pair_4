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
    public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.CompanyName).HasColumnName("CompanyName").IsRequired();
            builder.Property(e => e.Position).HasColumnName("Position").IsRequired();
            builder.Property(e => e.Sector).HasColumnName("Sector").IsRequired();
            builder.Property(e => e.City).HasColumnName("City").IsRequired();
            builder.Property(e => e.BusinessDescription).HasColumnName("BusinessDescription").IsRequired();
            builder.Property(e => e.BusinessStartDate).HasColumnName("BusinessStartDate").HasColumnType("date");
            builder.Property(e => e.BusinessEndDate).HasColumnName("BusinessEndDate").HasColumnType("date");

            builder.Property(e => e.Status).HasColumnType("bit");

            builder.HasOne(e => e.User)
                   .WithMany() 
                   .HasForeignKey("UserId");
        }
    }
}
