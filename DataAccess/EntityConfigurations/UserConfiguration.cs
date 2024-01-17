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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(b => b.Id);


            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.NationalityId).HasColumnName("NationalityId");
            builder.Property(b => b.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(b => b.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(b => b.Email).HasColumnName("Email").IsRequired();
            builder.Property(b => b.BirthDate).HasColumnName("BirthDate");
            builder.Property(b => b.Country).HasColumnName("Country");
            builder.Property(b => b.City).HasColumnName("City");
            builder.Property(b => b.District).HasColumnName("District");
            builder.Property(b => b.AddressDetails).HasColumnName("AddressDetails");
            builder.Property(b => b.AboutMe).HasColumnName("AboutMe");
            builder.Property(b => b.Phone).HasColumnName("Phone");

            builder.Property(b => b.Status).HasColumnName("Status");
            builder.Property(b => b.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(b => b.PasswordSalt).HasColumnName("PasswordSalt");

            builder.HasIndex(indexExpression: b => b.NationalityId, name: "UK_Users_NationalityId").IsUnique();
            builder.HasIndex(indexExpression: b => b.Email, name: "UK_Users_Email").IsUnique();


            builder.HasOne(c => c.Appeal).WithMany(cat => cat.Users).HasForeignKey(c => c.AppealId).IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); // categorydeki tüm dataya default olarak bu where koşulunu uygula. where deletedDate is null. Data silinmemişse getir.
        }
    }
}
