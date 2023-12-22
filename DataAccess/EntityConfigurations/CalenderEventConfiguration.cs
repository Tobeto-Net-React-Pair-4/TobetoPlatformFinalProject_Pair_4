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
    public class CalenderEventConfiguration : IEntityTypeConfiguration<CalendarEvent>
    {
        public void Configure(EntityTypeBuilder<CalendarEvent> builder)
        {
            builder.ToTable("CalendarEvents").HasKey(b => b.Id);
            
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.CourseId).HasColumnName("CourseId").IsRequired();
            builder.Property(b => b.EventDate).HasColumnName("EventDate").IsRequired();
            builder.Property(b => b.EventDetails).HasColumnName("EventDetails").IsRequired();
            

            builder.HasIndex(indexExpression: b => b.EventDate, name: "IX_CalendarEvents_EventDate");

            builder.HasOne(b => b.Course);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }

   
    }
}

