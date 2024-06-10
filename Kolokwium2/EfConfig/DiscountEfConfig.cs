using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium2.EfConfig;

public class DiscountEfConfig : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.ToTable("Client");

        builder.HasKey(c => c.IdDiscount);
        builder.Property(c => c.IdDiscount).ValueGeneratedOnAdd();

        builder.Property(c => c.Value).IsRequired();
        builder.Property(c => c.DateFrom).IsRequired();
        builder.Property(c => c.DateTo).IsRequired();
    }
}