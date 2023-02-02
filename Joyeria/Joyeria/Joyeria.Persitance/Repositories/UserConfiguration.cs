using Joyeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyeria.Persitance.Repositories
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(o => o.Id);

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired(false);

            builder.Property(c => c.LastName)
                .HasColumnName("LastName")
                .IsRequired(false);

            builder.Property(c => c.DocumentNumber)
                .HasColumnName("DocumentNumber")
                .IsRequired(false);

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .IsRequired(false);

            builder.Property(c => c.Password)
                .HasColumnName("Password")
                .IsRequired(false);

            builder.Property(c => c.Address)
                .HasColumnName("Address")
                .IsRequired(false);

            builder.Property(c => c.Cellphone)
                .HasColumnName("Cellphone")
                .IsRequired(false);

            builder.Property(c => c.UserTypeId)
                .HasColumnName("UserTypeId")
                .IsRequired(true);

            builder.Property(c => c.DocumentTypeId)
                .HasColumnName("DocumentTypeId")
                .IsRequired(true);
        }
    }
}
