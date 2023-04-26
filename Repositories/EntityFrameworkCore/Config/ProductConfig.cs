using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EntityFrameworkCore.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            builder
                .HasData(
                new Product() { Id = 1, ProductName = "Asus Laptop", Stock = 25, Price = 13500, CategoryId = 1},
                new Product() { Id = 2, ProductName = "Oppo A74", Stock = 12, Price = 8000, CategoryId = 2},
                new Product() { Id = 3, ProductName = "Samsung S20", Stock = 7, Price = 11000, CategoryId = 2 }
                );
        }
    }
}
