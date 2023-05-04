namespace Entities.RequestFeatures
{
    public class ProductParameters : RequestParameters
    {
        public uint MinPrice { get; set; } 
        public uint MaxPrice { get; set; } = uint.MaxValue;
        public bool ValidPriceRange => MaxPrice > MinPrice;
        public string? SearchTerm { get; set; }
        public ProductParameters()
        {
            OrderBy = "id";
        }
    }
}
