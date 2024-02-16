using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users").HasKey(u => u.Id);


            builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
            builder.Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
            builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
            builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
            builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
            builder.Property(u => u.Status).HasColumnName("Status").IsRequired();

            builder.HasOne(u => u.PersonalInfo).WithOne(p => p.User).HasForeignKey<PersonalInfo>(p => p.UserId);

            // builder.HasMany(b => b.Certificates);
            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); //  categorydeki tüm dataya default olarak bu where koşulunu uygula. where deletedDate is null. Data silinmemişse getir.
        }
    }
}
