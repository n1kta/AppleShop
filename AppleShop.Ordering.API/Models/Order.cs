using System.ComponentModel.DataAnnotations;

namespace AppleShop.Ordering.API.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string UserId { get; set; }

        public string? CouponCode { get; set; }

        public double OrderTotal { get; set; }

        public double DiscountTotal { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime PickUpDate { get; set; }

        public DateTime OrderTime { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CardNumber { get; set; }

        public string CVV { get; set; }

        public string ExpiryMonthYear { get; set; }

        public int CartTotalItems { get; set; }

        public ICollection<OrderLineItem> LineItems { get; set; }

        public bool PaymentStatus { get; set; }
    }
}
