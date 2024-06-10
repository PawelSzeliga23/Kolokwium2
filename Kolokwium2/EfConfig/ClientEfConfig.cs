using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kolokwium2.EfConfig;

public class ClientEfConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Client");

        builder.HasKey(c => c.IdCleint);
        builder.Property(c => c.IdCleint).ValueGeneratedOnAdd();

        builder.Property(c => c.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.LastName).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(100).IsRequired();
        builder.Property(c => c.Phone).HasMaxLength(100).IsRequired(false);

        builder.HasMany(c => c.Sales)
            .WithOne(s => s.IdClientNavigation)
            .HasForeignKey(s => s.IdClient).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(c => c.Payments)
            .WithOne(p => p.IdClientNavigation)
            .HasForeignKey(p => p.IdClient).OnDelete(DeleteBehavior.Cascade);
    }
}