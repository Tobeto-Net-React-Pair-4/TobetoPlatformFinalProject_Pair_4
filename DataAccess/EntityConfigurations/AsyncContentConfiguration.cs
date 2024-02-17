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
    public class AsyncContentConfiguration : IEntityTypeConfiguration<AsyncContent>
    {
        public void Configure(EntityTypeBuilder<AsyncContent> builder)
        {
            builder.ToTable("AsyncContents").HasKey(ac => ac.Id);

            builder.Property(ac => ac.Id).HasColumnName("Id").IsRequired();
            builder.Property(ac => ac.CategoryId).HasColumnName("CategoryId").IsRequired();
            builder.Property(ac => ac.LikeId).HasColumnName("LikeId").IsRequired();
            builder.Property(ac => ac.Name).HasColumnName("Name").IsRequired();
            builder.Property(ac => ac.Title).HasColumnName("Title").IsRequired();
            builder.Property(ac => ac.Status).HasColumnName("Status").IsRequired();
            builder.Property(ac => ac.VideoUrl).HasColumnName("VideoUrl").IsRequired();
            builder.Property(ac => ac.Language).HasColumnName("Language").IsRequired();
            builder.Property(ac => ac.Type).HasColumnName("Type").IsRequired();
            builder.Property(ac => ac.Company).HasColumnName("Company").IsRequired();
            builder.Property(ac => ac.Description).HasColumnName("Description").IsRequired();

            builder.HasQueryFilter(ac => !ac.DeletedDate.HasValue);

            builder.HasMany(ac => ac.CourseAsyncContents).WithOne(ca => ca.AsyncContent).HasForeignKey(ca => ca.AsyncContentId);
            builder.HasMany(ac => ac.ContentLikedByUsers).WithOne(lbu => lbu.AsyncContent).HasForeignKey(lbu => lbu.ContentId).OnDelete(DeleteBehavior.NoAction);
        }

    }
}
