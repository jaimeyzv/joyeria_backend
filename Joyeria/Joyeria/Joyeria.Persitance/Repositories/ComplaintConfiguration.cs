using Joyeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyeria.Persitance.Repositories
{
    public class ComplaintConfiguration : IEntityTypeConfiguration<Complaint>
    {
        public void Configure(EntityTypeBuilder<Complaint> builder)
        {
            builder.ToTable("Complaint");

            builder.HasKey(o => o.Id);

            builder.Property(c => c.Datec)
                .HasColumnName("Datec")
                .IsRequired(true);

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired(false);

            builder.Property(c => c.Address)
                .HasColumnName("Address")
                .IsRequired(false);

            builder.Property(c => c.Ndoc)
                .HasColumnName("Ndoc")
                .IsRequired(false);

            builder.Property(c => c.Email)
                .HasColumnName("Email")
                .IsRequired(false);

            builder.Property(c => c.Cellphone)
                .HasColumnName("Cellphone")
                .IsRequired(false);

            builder.Property(c => c.Repre)
                .HasColumnName("Repre")
                .IsRequired(false);

            builder.Property(c => c.Typep)
                .HasColumnName("Typep")
                .IsRequired(false);

            builder.Property(c => c.Price)
                .HasColumnName("Price")
                .IsRequired(false);

            builder.Property(c => c.Descp)
                .HasColumnName("Descp")
                .IsRequired(false);

            builder.Property(c => c.Typc)
                .HasColumnName("Typc")
                .IsRequired(false);

            builder.Property(c => c.Descc)
                .HasColumnName("Descc")
                .IsRequired(false);

            builder.Property(c => c.Pedic)
                .HasColumnName("Pedic")
                .IsRequired(false);

            builder.Property(c => c.StatusC)
                .HasColumnName("StatusC")
                .IsRequired(false);

        }
    }
}