using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityFrameworkCore.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasData(
                    new Category() { Id = 1, CategoryName = "Bilgisayar"},
                    new Category() { Id = 2, CategoryName = "Telefon" }
                );
        } 
    }
}
