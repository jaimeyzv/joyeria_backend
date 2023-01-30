using Joyeria.Domain.Entities;
using Joyeria.Persitance.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Joyeria.Persitance.Shared
{
    public class JoyeriaDbContext : DbContext
    {
        public JoyeriaDbContext(DbContextOptions<JoyeriaDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
    }
}
