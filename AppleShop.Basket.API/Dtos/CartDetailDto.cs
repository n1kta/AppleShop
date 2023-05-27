namespace AppleShop.Basket.API.Dtos;

public class CartDetailDto
{
    public int? CartDetailId { get; set; }

    public int? CartHeaderId { get; set; }

    public CartHeaderDto? CartHeader { get; set; }

    public Guid ProductId { get; set; }

    public ProductDetailResponse Product { get; set; }

    public int Count { get; set; }
}