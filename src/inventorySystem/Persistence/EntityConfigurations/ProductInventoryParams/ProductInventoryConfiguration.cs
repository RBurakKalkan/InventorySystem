using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.ProductInventoriesParams;

public class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
{
    public void Configure(EntityTypeBuilder<ProductInventory> builder)
    {
        builder.ToTable("ProductInventory").HasNoKey();
        builder.Property(pi => pi.ProductID).HasColumnName("ProductID");
        builder.Property(pi => pi.SKU).HasColumnName("SKU");
        builder.Property(pi => pi.Quantity).HasColumnName("Quantity");

    }
}