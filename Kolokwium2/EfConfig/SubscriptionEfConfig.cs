using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium2.EfConfig;

public class SubscriptionEfConfig : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscription");

        builder.HasKey(c => c.IdSubscription);
        builder.Property(c => c.IdSubscription).ValueGeneratedOnAdd();

        builder.Property(c => c.Name).HasMaxLength(100).IsRequired();
        builder.Property(c => c.RenewalPeriod).IsRequired();
        builder.Property(c => c.EndTime).IsRequired();
        builder.Property(c => c.Price).IsRequired();

        builder.HasMany(s => s.Sales)
            .WithOne(sa => sa.IdSubNavigation)
            .HasForeignKey(sa => sa.IdSubscription);
        builder.HasMany(s => s.Payments)
            .WithOne(p => p.IdSubNavigation)
            .HasForeignKey(p => p.IdSubscription);
        builder.HasMany(s => s.Discounts)
            .WithOne(d => d.IdSubNavigation)
            .HasForeignKey(d => d.IdSubscription);
    }
}