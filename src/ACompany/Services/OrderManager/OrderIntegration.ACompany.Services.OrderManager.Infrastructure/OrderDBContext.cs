using Microsoft.EntityFrameworkCore;
using OrderIntegration.ACompany.Services.OrderManager.Domain.OrderAggregate;

namespace OrderIntegration.ACompany.Services.OrderManager.Infrastructure
{
    public class OrderDBContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "ordering";
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().ToTable("Orders", DEFAULT_SCHEMA);
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems", DEFAULT_SCHEMA);
            modelBuilder.Entity<OrderItem>().Property(s => s.ItemName).HasMaxLength(250);
            modelBuilder.Entity<Order>().Property(s => s.ReceiverAddress).HasMaxLength(500);
            modelBuilder.Entity<Order>().Property(s => s.ReceiverName).HasMaxLength(500);
            modelBuilder.Entity<Order>().Property(s => s.CreatedDate).HasColumnType("datetime");
            base.OnModelCreating(modelBuilder);
        }
    }
}
