using AppleShop.Basket.API.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleShop.Basket.API.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Series { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ColorType Color { get; set; }

        public int Memory { get; set; }

        public int AvailableStock { get; set; }

        public string? PictureUri { get; set; }

        public double Price { get; set; }

        public string CategoryName { get; set; }
    }
}
