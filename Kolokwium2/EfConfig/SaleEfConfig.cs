using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium2.EfConfig;

public class SaleEfConfig: IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sale");

        builder.HasKey(c => c.IdSale);
        builder.Property(c => c.IdSale).ValueGeneratedOnAdd();

        builder.Property(s => s.CreatedAt).IsRequired();
    }
}