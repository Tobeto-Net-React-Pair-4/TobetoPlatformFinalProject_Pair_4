﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class SocialMediaConfiguration : IEntityTypeConfiguration<SocialMedia>
    {
        public void Configure(EntityTypeBuilder<SocialMedia> builder)
        {
            builder.ToTable("SocialMediaAccounts").HasKey(b => b.Id);

            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Url).HasColumnName("Url").IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
