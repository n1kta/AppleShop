namespace AppleShop.Ordering.API.Messages;

public class PaymentRequestDto
{
    public int OrderId { get; set; }

    public string Name { get; set; }

    public string CardNumber { get; set; }

    public string CVV { get; set; }

    public string ExpiryMonth { get; set; }

    public double OrderTotal { get; set; }

    public string Email { get; set; }
}