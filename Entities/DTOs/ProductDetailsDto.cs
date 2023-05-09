using Entities.Models;

namespace Entities.DTOs
{
    public record ProductDetailsDto : ProductDto
    {
        public Category Category { get; init; }
    }
}
