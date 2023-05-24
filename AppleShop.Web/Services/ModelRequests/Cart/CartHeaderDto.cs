﻿namespace AppleShop.Web.Services.ModelRequests.Cart
{
    public class CartHeaderDto
    {
        public int CartHeaderId { get; set; }

        public string UserId { get; set; }

        public string CouponCode { get; set; }

        public double OrderTotal { get; set; }

        public double DiscountTotal { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime PickUpDate { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string CardNumber { get; set; }

        public string CVV { get; set; }

        public string ExpiryMonthYear { get; set; }
    }
}