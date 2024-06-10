using Kolokwium2.EfConfig;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Context;

public class MyDbContext : DbContext
{
    public DbSet<Client> Clients;
    public DbSet<Sale> Sales;
    public DbSet<Subscription> Subscriptions;
    public DbSet<Discount> Discounts;
    public DbSet<Payment> Payments;

    protected MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClientEfConfig());
        modelBuilder.ApplyConfiguration(new SaleEfConfig());
        modelBuilder.ApplyConfiguration(new SubscriptionEfConfig());
        modelBuilder.ApplyConfiguration(new DiscountEfConfig());
        modelBuilder.ApplyConfiguration(new PaymentEfConfig());
    }
}