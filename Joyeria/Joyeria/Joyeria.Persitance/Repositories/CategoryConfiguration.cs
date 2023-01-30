using Joyeria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Joyeria.Persitance.Repositories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(o => o.Id);

            builder.Property(c => c.Name)
                .HasColumnName("Name")
                .IsRequired(false);
        }
    }
}
