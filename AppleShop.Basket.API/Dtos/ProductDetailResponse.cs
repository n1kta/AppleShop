namespace AppleShop.Basket.API.Dtos;

public sealed class ProductDetailResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Series { get; set; }
    public string Description { get; set; }
    public ColorTypeResponse Color { get; set; }
    public int Memory { get; set; }
    public bool IsAvailable { get; set; }
    public int AvailableStock { get; set; }
    public string? PictureUri { get; set; }
    public double Price { get; set; }
    public string CategoryName { get; set; }
}