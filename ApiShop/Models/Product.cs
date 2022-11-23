using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(40)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public int Amount { get; set; }
        public double Value { get; set; }

        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

        public int SellerId { get; set; }

        [JsonIgnore]
        public Seller? Seller { get; set; }
    }
}
