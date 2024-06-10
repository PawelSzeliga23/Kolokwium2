using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium2.EfConfig;

public class PaymentEfConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payment");

        builder.HasKey(c => c.IdPayment);
        builder.Property(c => c.IdPayment).ValueGeneratedOnAdd();

        builder.Property(c => c.Date).IsRequired();
    }
}