namespace AppleShop.Ordering.API.Messages;

public class UpdatePaymentResultDto
{
    public int OrderId { get; set; }

    public bool Status { get; set; }

    public string Email { get; set; }
}