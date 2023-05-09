using Entities.Models;

namespace Entities.DTOs
{
    public record CategoryDetailsDto
    {
        public int Id { get; init; }
        public string CategoryName { get; init; }
        public ICollection<ProductDto> Products { get; init; }
    }
}
