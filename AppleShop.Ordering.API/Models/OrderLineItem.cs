using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleShop.Ordering.API.Models
{
    public class OrderLineItem
    {
        [Key]
        public int LineItemId { get; set; }

        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double Price { get; set; }

        public int Count { get; set; }
    }
}
