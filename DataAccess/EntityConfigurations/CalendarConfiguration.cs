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
    public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
    {
        public void Configure(EntityTypeBuilder<Calendar> builder)
        {
            builder.ToTable("Calendars").HasKey(b => b.Id);
            
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CourseId).HasColumnName("CourseId").IsRequired();
            builder.Property(b => b.EventDate).HasColumnName("EventDate").IsRequired();
            builder.Property(b => b.EventDetails).HasColumnName("EventDetails").IsRequired();
            builder.Property(b => b.StatusOfCompleted).HasColumnName("StatusOfCompleted").IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);


            builder.HasMany(uc => uc.UserCalendars).WithOne(c=>c.Calendar).HasForeignKey(c=>c.CalendarId);

        }

   
    }
}

