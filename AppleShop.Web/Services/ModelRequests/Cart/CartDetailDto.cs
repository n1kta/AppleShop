using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleShop.Web.Services.ModelRequests.Cart
{
    public class CartDetailDto
    {
        public int CartDetailId { get; set; }

        public int CartHeaderId { get; set; }

        public CartHeaderDto CartHeader { get; set; }

        public int ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int Count { get; set; }
    }
}
