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
    public class ContentLikedByUserConfiguration : IEntityTypeConfiguration<ContentLikedByUser>
    {
        public void Configure(EntityTypeBuilder<ContentLikedByUser> builder)
        {
            builder.Ignore(a => a.Id);
            builder.ToTable("ContentLikedByUsers").HasKey(a => new { a.UserId, a.ContentId });

            builder.Property(a => a.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(a => a.ContentId).HasColumnName("ContentId").IsRequired();

            builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
        }
    }
}
