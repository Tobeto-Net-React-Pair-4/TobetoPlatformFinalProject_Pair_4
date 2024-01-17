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
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.Ignore(b => b.Id);
            builder.ToTable("UserOperationClaims").HasKey(s => new { s.UserId, s.OperationClaimId });

            builder.Property(b => b.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(b => b.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

            builder.HasOne(s => s.User).WithMany(c => c.OperationClaims).HasForeignKey(c => c.UserId);
            builder.HasOne(s => s.OperationClaim).WithMany(c => c.Users).HasForeignKey(c => c.OperationClaimId);
        }
    }
}
