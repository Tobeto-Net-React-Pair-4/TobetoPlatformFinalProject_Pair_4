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

            builder.HasIndex(u => u.Email, "UK_Users_Email").IsUnique();

            builder.HasOne(u => u.PersonalInfo).WithOne(p => p.User).HasForeignKey<PersonalInfo>(p => p.UserId);
            builder.HasMany(u => u.CourseFavouritedByUser).WithOne(cfbu => cfbu.User).HasForeignKey(cfbu => cfbu.UserId);
            builder.HasMany(u => u.ContentLikedByUsers).WithOne(clbu => clbu.User).HasForeignKey(clbu => clbu.UserId);
            builder.HasMany(u => u.UserCalendars).WithOne(uc => uc.User).HasForeignKey(uc => uc.UserId);
            builder.HasMany(u => u.PasswordResets).WithOne(uc => uc.User).HasForeignKey(uc => uc.UserId);

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue); 
        }
    }
}
