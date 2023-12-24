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
    public class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Surveys").HasKey(b => b.Id);


            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Title).HasColumnName("Title").IsRequired();
            builder.Property(b => b.Description).HasColumnName("Description").IsRequired();
            builder.Property(b => b.Url).HasColumnName("Url").IsRequired();

            
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
