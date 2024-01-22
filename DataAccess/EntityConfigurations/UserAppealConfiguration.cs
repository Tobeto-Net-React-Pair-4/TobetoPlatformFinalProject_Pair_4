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
    public class UserAppealConfiguration : IEntityTypeConfiguration<UserAppeal>
    {
        public void Configure(EntityTypeBuilder<UserAppeal> builder)
        {
            builder.Ignore(i => i.Id);
            builder.ToTable("UserAppeals").HasKey(s => new { s.AppealId, s.UserId });

            builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(s => s.AppealId).HasColumnName("AppealId").IsRequired();


            builder.HasOne(s => s.Appeal).WithMany(c => c.UserAppeals).HasForeignKey(c => c.AppealId);
            builder.HasOne(s => s.User).WithMany(c => c.UserAppeals).HasForeignKey(c => c.UserId);

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        }
    }
}
