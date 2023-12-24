using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class UserSurveyConfiguration : IEntityTypeConfiguration<UserSurvey>
    {
        public void Configure(EntityTypeBuilder<UserSurvey> builder)
        {
            builder.Ignore(i => i.Id);
            builder.ToTable("UserSurveys").HasKey(s => new { s.SurveyId, s.UserId });

            builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(s => s.SurveyId).HasColumnName("SurveyId").IsRequired();

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

            builder.HasOne(s => s.Survey).WithMany(c => c.UserSurveys).HasForeignKey(c => c.SurveyId);
            builder.HasOne(s => s.User).WithMany(c => c.UserSurveys).HasForeignKey(c => c.UserId);
        }
    }
}
