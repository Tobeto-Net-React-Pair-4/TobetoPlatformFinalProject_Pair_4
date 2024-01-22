using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class QuestionAnswerConfiguration : IEntityTypeConfiguration<QuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
        {
            builder.ToTable("QuestionAnswers").HasKey(qa => qa.Id);

            builder.Property(qa => qa.Id).HasColumnName("Id").IsRequired();
            builder.Property(qa => qa.Description).HasColumnName("Description").IsRequired();
            builder.Property(qa => qa.ImageUrl).HasColumnName("ImageUrl");

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
