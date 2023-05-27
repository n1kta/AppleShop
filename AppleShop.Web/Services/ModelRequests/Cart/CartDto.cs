namespace AppleShop.Web.Services.ModelRequests.Cart
{
    public class CartDto
    {
        public CartHeaderDto? CartHeader { get; set; }

        public IEnumerable<CartDetailDto>? CartDetails { get; set; }
    }
}
