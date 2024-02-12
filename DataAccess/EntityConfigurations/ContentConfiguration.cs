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
    public class ContentConfiguration : IEntityTypeConfiguration<Content>
    {
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.ToTable("Contents").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CourseId).HasColumnName("CourseId").IsRequired();
            builder.Property(b => b.Type).HasColumnName("Type").IsRequired();
            builder.Property(b => b.VideoUrl).HasColumnName("VideoUrl").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
            builder.Property(b => b.Score).HasColumnName("Score").IsRequired();
            builder.Property(b => b.Language).HasColumnName("Language").IsRequired();
            builder.Property(b => b.Detail).HasColumnName("Detail").IsRequired();


            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Content_Name").IsUnique();

            builder.HasOne(b => b.Course);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
