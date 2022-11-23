using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiShop.Models
{
    public class Seller
    {
        [Key]
        public int SellerId { get; set; }

        [Required]
        [MaxLength(80)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Format invalid for Email!")]
        [MaxLength(50)]
        public string? Email { get; set; }

        [Required]
        [MaxLength(50)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Enter a password with at least 8 characters!")]
        public string? Password { get; set; }

        [Required]
        [MaxLength(300)]
        [StringLength(300, MinimumLength = 20, ErrorMessage = "Minimum 20 characters is required!")]
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Product> Products { get; set; } = new Collection<Product>();
    }
}
