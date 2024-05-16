using Microsoft.EntityFrameworkCore;
using OrderIntegration.BCompany.Entities.Entities;

namespace OrderIntegration.BCompany.DataAccess.Context
{
    public class BCompanyDbContext : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public BCompanyDbContext(DbContextOptions<BCompanyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(s => s.OrderItems)
                .HasForeignKey(su => su.OrderId);

            modelBuilder.Entity<OrderItem>()
              .Property(s => s.ItemName)
              .HasMaxLength(250);

            modelBuilder.Entity<Order>()
               .Property(s => s.ReceiverAddress)
               .HasMaxLength(500);
            modelBuilder.Entity<Order>()
               .Property(s => s.ReceiverName)
               .HasMaxLength(500);
            modelBuilder.Entity<Order>()
                .Property(s => s.CreatedDate)
                .HasColumnType("datetime");

        }
    }
}
