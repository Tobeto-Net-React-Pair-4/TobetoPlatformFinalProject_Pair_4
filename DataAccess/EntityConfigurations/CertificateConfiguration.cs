using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificates").HasKey(b => b.Id);
            builder.Property(b => b.Name).HasColumnName("Name");
            builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
            builder.Property(b => b.Type).HasColumnName("Type");
            builder.Property(b => b.Date).HasColumnName("Date");

            builder.HasOne(c => c.User).WithMany(u => u.Certificates).HasForeignKey(c => c.UserId);

        }
    }
}
