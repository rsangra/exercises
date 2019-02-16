using Newtonsoft.Json;

namespace WooliesX.Exercises.Models
{
    public class ProductInfo
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductQuantity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
    
    public class Special
    {
        public decimal Total { get; set; }

        public ProductQuantity[] Quantities { get; set; }

        [JsonIgnore]
        internal decimal DiscountRate { get; set; }

        [JsonIgnore]
        internal decimal StandardPrice { get; set; }
    }
    public class Trolley
    {
        public ProductInfo[] Products { get; set; }
        public Special[] Specials { get; set; }
        public ProductQuantity[] Quantities { get; set; }

    }
}