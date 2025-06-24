using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Data;

public class OrderHistoryDbContext(DbContextOptions<OrderHistoryDbContext> options) : DbContext(options)
{
    public DbSet<OrderHistory> Orders => Set<OrderHistory>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();

    override protected void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<OrderHistory>()
            .HasMany(o => o.OrderDetails)
            .WithOne(d => d.OrderHistory)
            .HasForeignKey(d => d.Order_Id)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderDetail>()
            .Property(d => d.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderDetail>()
            .Property(d => d.Discount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderHistory>()
            .Property(h => h.BillAmount)
            .HasPrecision(18, 2);
    }
}