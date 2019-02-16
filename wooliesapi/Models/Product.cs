using Newtonsoft.Json;

namespace WooliesX.Exercises.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        [JsonConverter(typeof(ParseNumbersAsInt32Converter))]
        public int Quantity { get; set; }
    }
}