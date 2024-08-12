using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeApi.Domain.Entities;

namespace TradeApi.Persistence.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            Faker faker = new("tr");

            Product product1 = new()
            {
                Id = 1,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 1,
                Price = faker.Finance.Amount(10, 1000),
                Discount = faker.Random.Decimal(0, 10),
                CreatedDate = DateTime.Now,
                IsDeleted= false
            };

            Product product2 = new()
            {
                Id = 2,
                Title = faker.Commerce.ProductName(),
                Description = faker.Commerce.ProductDescription(),
                BrandId = 3,
                Price = faker.Finance.Amount(10, 1000),
                Discount = faker.Random.Decimal(0, 10),
                CreatedDate = DateTime.Now,
                IsDeleted = false
            };

            builder.HasData(product1, product2);
        }
    }
}
