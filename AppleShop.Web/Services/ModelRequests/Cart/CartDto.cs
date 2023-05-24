using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppleShop.Web.Services.ModelRequests.Cart
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }

        public IEnumerable<CartDetailDto> CartDetails { get; set; }
    }
}
