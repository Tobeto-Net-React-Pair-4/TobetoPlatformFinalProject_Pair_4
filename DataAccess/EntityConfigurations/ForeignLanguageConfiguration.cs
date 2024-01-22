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
    public class ForeignLanguageConfiguration : IEntityTypeConfiguration<ForeignLanguage>
    {
        public void Configure(EntityTypeBuilder<ForeignLanguage> builder)
        {
            builder.ToTable("ForeignLanguages");

            builder.HasKey(fl => fl.Id);
            builder.Property(fl => fl.LanguageList).HasColumnName("LanguageList").IsRequired();
            builder.Property(fl => fl.LanguageLevel).HasColumnName("LanguageLevel").IsRequired();
            builder.HasOne(fl => fl.User).WithMany() 
                   .HasForeignKey("UserId"); 
        }
    }
}
