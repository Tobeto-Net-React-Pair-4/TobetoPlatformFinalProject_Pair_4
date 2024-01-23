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
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.ToTable("ExamQuestions").HasKey(eq => eq.Id);

            builder.Property(eq => eq.Id).HasColumnName("Id").IsRequired();
            builder.Property(eq => eq.Description).HasColumnName("Description").IsRequired();
            builder.Property(eq => eq.ImageUrl).HasColumnName("ImageUrl");
            builder.Property(eq => eq.TrueAnswerId).HasColumnName("TrueAnswerId").IsRequired();

            builder.HasMany(eq => eq.QuestionAnswers).WithOne(qa => qa.ExamQuestion).HasForeignKey(qa => qa.QuestionId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
