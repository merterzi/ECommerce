using Entities.Models;

namespace Entities.DTOs
{
    public record ProductDto
    {
        public int Id { get; init; }
        public int CategoryId { get; init; }
        public string ProductName { get; init; }
        public int Stock { get; init; }
        public decimal Price { get; init; }
    }
}
