using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.InventoriesParams;

public class InventoryConfiguration : IEntityTypeConfiguration<Inventory>
{
    public void Configure(EntityTypeBuilder<Inventory> builder)
    {
        builder.ToTable("Inventory").HasKey(i => i.SKU);

        builder.Property(i => i.SKU).HasColumnName("SKU").IsRequired();
        builder.Property(i => i.Unit).HasColumnName("Unit");
        builder.Property(i => i.FriendlyName).HasColumnName("FriendlyName");

    }
}