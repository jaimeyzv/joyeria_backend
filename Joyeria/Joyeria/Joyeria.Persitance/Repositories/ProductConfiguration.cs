using Joyeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyeria.Persitance.Repositories
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(o => o.Id);

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired(false);

            builder.Property(c => c.Description)
                .HasColumnName("Description")
                .IsRequired(false);

            builder.Property(c => c.Stock)
                .HasColumnName("Stock")
                .IsRequired(true);

            builder.Property(c => c.Price)
                .HasColumnName("Price")
                .IsRequired(true);

            builder.Property(c => c.Image)
                .HasColumnName("Image")
                .IsRequired(false);

            builder.Property(c => c.CategoryId)
                .HasColumnName("Category_id")
                .IsRequired(true);
        }
    }
}
