using System.ComponentModel.DataAnnotations;

namespace AppleShop.Basket.API.Models
{
    public class CartHeader
    {
        [Key]
        public int CartHeaderId { get; set; }

        public string UserId { get; set; }
    }
}
