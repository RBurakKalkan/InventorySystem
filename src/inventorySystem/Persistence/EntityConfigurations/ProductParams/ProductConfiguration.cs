using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations.ProductsParams;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.Name).HasColumnName("Name");
        builder.Property(p => p.Description).HasColumnName("Description");
        builder.Property(p => p.Brand).HasColumnName("Brand");
        builder.Property(p => p.Price).HasColumnName("Price");
        builder.Property(p => p.CategoryID).HasColumnName("CategoryID");
    }
}