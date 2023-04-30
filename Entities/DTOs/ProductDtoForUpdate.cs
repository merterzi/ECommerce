namespace Entities.DTOs
{
    public record ProductDtoForUpdate : ProductDtoForManipulation
    {
        public int Id { get; init; }
    }
}
