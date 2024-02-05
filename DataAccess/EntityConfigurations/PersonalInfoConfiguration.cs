using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class PersonalInfoConfiguration : IEntityTypeConfiguration<PersonalInfo>
    {
        public void Configure(EntityTypeBuilder<PersonalInfo> builder)
        {
            builder.ToTable("PersonalInfos").HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(p => p.NationalityId).HasColumnName("NationalityId");
            builder.Property(p => p.BirthDate).HasColumnName("BirthDate");
            builder.Property(p => p.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(p => p.Country).HasColumnName("Country");
            builder.Property(p => p.City).HasColumnName("City");
            builder.Property(p => p.District).HasColumnName("District");
            builder.Property(p => p.AddressDetails).HasColumnName("AddressDetails");
            builder.Property(p => p.AboutMe).HasColumnName("AboutMe");
            builder.Property(p => p.ImageUrl).HasColumnName("ImageUrl");

            builder.HasIndex(indexExpression: b => b.NationalityId, name: "UK_PersonalInfos_NationalityId").IsUnique();

            builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
        }
    }
}
