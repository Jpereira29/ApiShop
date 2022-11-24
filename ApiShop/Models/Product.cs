using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiShop.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(60, MinimumLength = 3)]
        [MaxLength(60)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [StringLength(300, MinimumLength = 10)]
        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [JsonIgnore]
        public Category? Category { get; set; }

        [Required]
        public int SellerId { get; set; }

        [JsonIgnore]
        public Seller? Seller { get; set; }
    }
}
