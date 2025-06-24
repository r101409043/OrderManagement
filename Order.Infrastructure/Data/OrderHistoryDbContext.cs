using Microsoft.EntityFrameworkCore;
using Order.ApplicationCore.Entities;

namespace Order.Infrastructure.Data;

public class OrderHistoryDbContext(DbContextOptions<OrderHistoryDbContext> options) : DbContext(options)
{
    public DbSet<OrderHistory> Orders => Set<OrderHistory>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Payment> Payments { get; set; }


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

        modelBuilder.Entity<UserAddress>()
            .HasOne(ua => ua.Customer)
            .WithMany(c => c.UserAddresses)
            .HasForeignKey(ua => ua.Customer_Id);

        modelBuilder.Entity<UserAddress>()
            .HasOne(ua => ua.Address)
            .WithMany(a => a.UserAddresses)
            .HasForeignKey(ua => ua.Address_Id);

        modelBuilder.Entity<Payment>()
            .Property(p => p.Amount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<ShoppingCartItem>()
            .Property(i => i.Price)
            .HasPrecision(18, 2);
    }
}