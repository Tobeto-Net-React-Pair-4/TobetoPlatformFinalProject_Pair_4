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
    public class InstructorSessionConfiguration : IEntityTypeConfiguration<InstructorSession>
    {
        public void Configure(EntityTypeBuilder<InstructorSession> builder)
        {
            builder.Ignore(ins => ins.Id);
            builder.ToTable("InstructorSessions").HasKey(ins => new { ins.SessionId, ins.InstructorId });

            builder.Property(ins => ins.SessionId).HasColumnName("SessionId").IsRequired();
            builder.Property(ins => ins.InstructorId).HasColumnName("InstructorId").IsRequired();

            builder.HasQueryFilter(ins => !ins.DeletedDate.HasValue);
        }
    }
}
