﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims").HasKey(op => op.Id);

            builder.Property(op => op.Id).HasColumnName("Id").IsRequired();
            builder.Property(op => op.Name).HasColumnName("Name").IsRequired();

            builder.HasQueryFilter(op => !op.DeletedDate.HasValue);

            builder.HasMany(op => op.Users).WithOne(uc => uc.OperationClaim).HasForeignKey(uc => uc.OperationClaimId);
        }
    }
}
