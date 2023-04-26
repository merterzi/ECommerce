namespace Entities
{
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
    }
}
