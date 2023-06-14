namespace AppleShop.Ordering.API.DTOs;

public class OrderDto
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string CardNumber { get; set; }

    public int CartTotalItems { get; set; }

    public double OrderTotal { get; set; }
}