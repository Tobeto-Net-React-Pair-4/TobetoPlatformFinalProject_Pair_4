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
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.Name).HasColumnName("Name").IsRequired();
            builder.HasMany(b => b.Users);

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_OperationClaims_Name").IsUnique();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
