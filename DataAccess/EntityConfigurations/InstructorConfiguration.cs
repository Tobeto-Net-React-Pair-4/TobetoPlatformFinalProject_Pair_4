﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.ToTable("Instructors").HasKey(i => i.Id);

            builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
            builder.Property(i => i.Name).HasColumnName("Name").IsRequired();

            builder.HasQueryFilter(i => !i.DeletedDate.HasValue);

            builder.HasMany(i => i.InstructorSessions).WithOne(ins => ins.Instructor).HasForeignKey(ins => ins.InstructorId);
            builder.HasMany(i => i.Calendars).WithOne(c => c.Instructor).HasForeignKey(c => c.InstructorId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
