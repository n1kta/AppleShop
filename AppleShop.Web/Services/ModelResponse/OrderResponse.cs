namespace AppleShop.Web.Services.ModelResponse;

public class OrderResponse
{
    public string FullName { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string CardNumber { get; set; }

    public int CartTotalItems { get; set; }

    public double OrderTotal { get; set; }
}