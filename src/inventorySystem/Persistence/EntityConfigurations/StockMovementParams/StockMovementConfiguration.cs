using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.StockMovementsParams;

public class StockMovementConfiguration : IEntityTypeConfiguration<StockMovement>
{
    public void Configure(EntityTypeBuilder<StockMovement> builder)
    {
        builder.ToTable("StockMovements").HasKey(sm => sm.Id);

        builder.Property(sm => sm.Id).HasColumnName("Id").IsRequired();
        builder.Property(sm => sm.SKU).HasColumnName("SKU");
        builder.Property(sm => sm.MovementType).HasColumnName("MovementType");
        builder.Property(sm => sm.Quantity).HasColumnName("Quantity");
        builder.Property(sm => sm.MovementDate).HasColumnName("MovementDate");
    }
}