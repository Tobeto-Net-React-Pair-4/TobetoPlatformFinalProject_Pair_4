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
    public class UserExamConfiguration : IEntityTypeConfiguration<UserExam>
    {
        public void Configure(EntityTypeBuilder<UserExam> builder)
        {
            builder.Ignore(ue => ue.Id);
            builder.ToTable("UserExams").HasKey(ue => new { ue.ExamId, ue.UserId });

            builder.Property(ue => ue.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(ue => ue.ExamId).HasColumnName("ExamId").IsRequired();


            builder.HasOne(ue => ue.Exam).WithMany(e => e.ExamUsers).HasForeignKey(ue => ue.ExamId);
            builder.HasOne(ue => ue.User).WithMany(u => u.UserExams).HasForeignKey(ue => ue.UserId);

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        }
    }
}
