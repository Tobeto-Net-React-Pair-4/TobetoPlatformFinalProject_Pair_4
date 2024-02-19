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
    public class UserCalendarConfiguration : IEntityTypeConfiguration<UserCalendar>
    {
        public void Configure(EntityTypeBuilder<UserCalendar> builder)
        {
            builder.Ignore(u => u.Id);
            builder.ToTable("UserCalendars").HasKey(u => new { u.UserId, u.CalendarId });

            builder.Property(u => u.UserId).HasColumnName("UserId").IsRequired();
            builder.Property(u => u.CalendarId).HasColumnName("CalendarId").IsRequired();

            builder.HasQueryFilter(u => !u.DeletedDate.HasValue);
        }
    }
}
