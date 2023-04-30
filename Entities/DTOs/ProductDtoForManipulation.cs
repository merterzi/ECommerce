namespace Entities.DTOs
{
    public record ProductDtoForManipulation
    {
        public int CategoryId { get; init; }
        public string ProductName { get; init; }
        public int Stock { get; init; }
        public decimal Price { get; init; }
    }
}
