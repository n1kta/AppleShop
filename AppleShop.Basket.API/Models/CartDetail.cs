﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppleShop.Basket.API.Models
{
    public class CartDetail
    {
        [Key]
        public int CartDetailId { get; set; }

        public int CartHeaderId { get; set; }

        [ForeignKey(nameof(CartHeaderId))]
        public virtual CartHeader CartHeader { get; set;}

        public Guid ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }

        public int Count { get; set; }
    }
}
