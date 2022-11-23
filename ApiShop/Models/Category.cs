using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using ApiShop.Context;

namespace ApiShop.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required!")]
        [StringLength(15, MinimumLength = 3)]
        [MaxLength(15)]
        public string? Name { get; set; }
        public ICollection<Product> Products { get; set; } = new Collection<Product>();
    }
}
