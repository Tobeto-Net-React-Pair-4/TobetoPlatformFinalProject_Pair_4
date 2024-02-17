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
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions").HasKey(s => s.Id);

            builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
            builder.Property(s => s.LiveContentId).HasColumnName("LiveContentId").IsRequired();
            builder.Property(s => s.RecordUrl).HasColumnName("RecordUrl").IsRequired();
            builder.Property(s => s.SessionUrl).HasColumnName("SessionLinkUrl").IsRequired();
            builder.Property(s => s.StartOfTime).HasColumnName("StartOfTime").IsRequired();
            builder.Property(s => s.EndOfTime).HasColumnName("EndOfTime").IsRequired();

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

            builder.HasMany(s => s.ınstructorSessions).WithOne(ins => ins.Session).HasForeignKey(ins => ins.SessionId);
        }
    }
}
