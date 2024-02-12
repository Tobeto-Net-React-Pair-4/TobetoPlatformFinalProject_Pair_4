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
    public class LikedConfiguration : IEntityTypeConfiguration<Liked>
    {
        public void Configure(EntityTypeBuilder<Liked> builder)
        {
            builder.ToTable("Likeds").HasKey(b => b.Id);

            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Count).HasColumnName("Count").IsRequired();


            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
