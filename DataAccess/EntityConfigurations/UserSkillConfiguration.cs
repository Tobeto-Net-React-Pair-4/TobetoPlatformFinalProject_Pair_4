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
    public class UserSkillConfiguration : IEntityTypeConfiguration<UserSkill>
    {
        public void Configure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.Ignore(i => i.Id);
            builder.ToTable("UserSkills").HasKey(s => new { s.SkillId, s.UserId });

            builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(s => s.SkillId).HasColumnName("SkillId").IsRequired();


            builder.HasOne(s => s.Skill).WithMany(c => c.UserSkills).HasForeignKey(c => c.SkillId);
            builder.HasOne(s => s.User).WithMany(c => c.UserSkills).HasForeignKey(c => c.UserId);

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);
        }
    }
}
