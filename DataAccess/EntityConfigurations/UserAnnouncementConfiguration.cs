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
    public class UserAnnouncementConfiguration : IEntityTypeConfiguration<UserAnnouncement>
    {
        public void Configure(EntityTypeBuilder<UserAnnouncement> builder)
        {
            builder.Ignore(i => i.Id);
            builder.ToTable("UserAnnouncements").HasKey(s => new { s.AnnouncementId, s.UserId });

            builder.Property(s => s.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(s => s.AnnouncementId).HasColumnName("AnnouncementId").IsRequired();

            builder.HasQueryFilter(s => !s.DeletedDate.HasValue);

            builder.HasOne(s => s.Announcement).WithMany(c => c.UserAnnouncements).HasForeignKey(c => c.AnnouncementId);
            builder.HasOne(s => s.User).WithMany(c => c.UserAnnouncements).HasForeignKey(c => c.UserId);

        }
    }
}
