using Entities.Models;
using System.Linq.Dynamic.Core;

namespace Repositories.EntityFrameworkCore.Extensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilterProducts(this IQueryable<Product> products, uint minPrice, uint maxPrice) =>
            products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

        public static IQueryable<Product> Search(this IQueryable<Product> products, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return products;

            string lowerCaseTerm = searchTerm.Trim().ToLower();
            return products.Where(p => p.ProductName.ToLower().Contains(lowerCaseTerm));
        }

        public static IQueryable<Product> Sort(this IQueryable<Product> products, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
                return products.OrderBy(p => p.Id);

            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Product>(orderByQueryString);

            if (string.IsNullOrWhiteSpace(orderQuery))
                return products.OrderBy(p => p.Id);

            return products.OrderBy(orderQuery);
        }
    }
}
