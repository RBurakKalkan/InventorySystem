using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.UnitConversionsParams;

public class UnitConversionConfiguration : IEntityTypeConfiguration<UnitConversion>
{
    public void Configure(EntityTypeBuilder<UnitConversion> builder)
    {
        builder.ToTable("UnitConversions").HasNoKey();
        builder.Property(uc => uc.SKU).HasColumnName("SKU");
        builder.Property(uc => uc.BaseUnit).HasColumnName("BaseUnit");
        builder.Property(uc => uc.ConvertedUnit).HasColumnName("ConvertedUnit");
        builder.Property(uc => uc.ConversionFactor).HasColumnName("ConversionFactor");
    }
}