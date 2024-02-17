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
    public class LiveContentConfiguration : IEntityTypeConfiguration<LiveContent>
    {
        public void Configure(EntityTypeBuilder<LiveContent> builder)
        {
            builder.ToTable("LiveContents").HasKey(l => l.Id);

            builder.Property(l => l.Id).HasColumnName("Id").IsRequired();
            builder.Property(l => l.CategoryId).HasColumnName("CategoryId").IsRequired();
            builder.Property(l => l.LikeId).HasColumnName("LikeId").IsRequired();
            builder.Property(l => l.Title).HasColumnName("Title").IsRequired();
            builder.Property(l => l.Name).HasColumnName("Name").IsRequired();
            builder.Property(l => l.Status).HasColumnName("Status").IsRequired();

            builder.HasQueryFilter(l => !l.DeletedDate.HasValue);

            builder.HasMany(l => l.Sessions).WithOne(s => s.LiveContent).HasForeignKey(s => s.LiveContentId);
            builder.HasMany(l => l.CourseLiveContents).WithOne(cl => cl.LiveContent).HasForeignKey(cl => cl.LiveContentId);
            builder.HasMany(l => l.ContentLikedByUsers).WithOne(cl => cl.LiveContent).HasForeignKey(cl => cl.ContentId);
            builder.HasMany(l => l.Homeworks).WithOne(cl => cl.LiveContent).HasForeignKey(cl => cl.LiveContentId);
        }
    }
}
