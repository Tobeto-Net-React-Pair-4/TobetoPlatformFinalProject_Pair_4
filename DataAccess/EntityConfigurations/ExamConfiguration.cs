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
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams").HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("Id").IsRequired();
            builder.Property(e => e.Title).HasColumnName("Title").IsRequired();
            builder.Property(e => e.Description).HasColumnName("Description").IsRequired();
            builder.Property(e => e.Time).HasColumnName("Time").IsRequired();
            builder.Property(e => e.QuestionQuantity).HasColumnName("QuestionQuantity").IsRequired();
            builder.Property(e => e.ExamType).HasColumnName("ExamType").IsRequired();
            builder.Property(e => e.IsCompleted).HasColumnName("IsCompleted").IsRequired();
            builder.Property(e => e.Score).HasColumnName("Score").IsRequired();
            builder.Property(e => e.TrueAnswerCount).HasColumnName("TrueAnswerCount").IsRequired();
            builder.Property(e => e.FalseAnswerCount).HasColumnName("FalseAnswerCount").IsRequired();
            builder.Property(e => e.EmptyAnswerCount).HasColumnName("EmptyAnswerCount").IsRequired();
            builder.Property(e => e.ExamStartDate).HasColumnName("ExamStartDate").IsRequired();
            builder.Property(e => e.ExamEndDate).HasColumnName("ExamEndDate").IsRequired();

            builder.HasMany(e => e.ExamQuestions).WithOne(eq => eq.Exam).HasForeignKey(eq => eq.ExamId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }
    }
}
