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
    public class PasswordRestConfiguration : IEntityTypeConfiguration<PasswordReset>
    {
        public void Configure(EntityTypeBuilder<PasswordReset> builder)
        {
            builder.ToTable("PasswordReset").HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
            builder.Property(f => f.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(f => f.Code).HasColumnName("Code").IsRequired();

            builder.HasQueryFilter(f => !f.DeletedDate.HasValue);
        }
    }
}
