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
    public class LikeConfiguration : IEntityTypeConfiguration<Like>
    {
        public void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.ToTable("Likes").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Count).HasColumnName("Count").IsRequired();

            builder.HasOne(l => l.Course).WithOne(c => c.Like).HasForeignKey<Course>(c => c.LikeId);
            builder.HasOne(l => l.AsyncContent).WithOne(ac => ac.Like).HasForeignKey<AsyncContent>(ac => ac.LikeId);
            builder.HasOne(l => l.LiveContent).WithOne(lc => lc.Like).HasForeignKey<LiveContent>(lc => lc.LikeId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);


        }
    }
}
