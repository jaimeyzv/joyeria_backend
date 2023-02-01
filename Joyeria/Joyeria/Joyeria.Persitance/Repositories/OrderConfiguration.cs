using Joyeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyeria.Persitance.Repositories
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(c => c.Date)
                .HasColumnName("Date")
                .IsRequired();

            builder.Property(c => c.UserId)
                .HasColumnName("UserId")
                .IsRequired();

            builder.Property(c => c.StatusId)
                .HasColumnName("StatusId")
                .IsRequired();

            builder.Property(c => c.Total)
                .HasColumnName("Total")
                .IsRequired();
        }
    }
}
