using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.ToTable("UserOperationClaims").Ignore(u => u.Id);
            builder.HasKey(uop => new { uop.UserId, uop.OperationClaimId });

            builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(u => u.OperationClaimId).HasColumnName("OperationClaimId").IsRequired();

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        }
    }
}
