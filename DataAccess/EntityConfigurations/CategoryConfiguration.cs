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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(b => b.Id);


            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Name).HasColumnName("Name").IsRequired();

            builder.HasIndex(indexExpression: b => b.Name, name: "UK_Categories_Name").IsUnique();



            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //  categorydeki tüm dataya default olarak bu where koşulunu uygula. where deletedDate is null. Data silinmemişse getir.
        }
    }
}
