using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppleShop.Product.API.Infrastructure.EntityConfigurations;

public sealed class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Models.Product>
{
    public void Configure(EntityTypeBuilder<Models.Product> builder)
    {
        builder.HasQueryFilter(p => !p.IsDeleted);
    }
}