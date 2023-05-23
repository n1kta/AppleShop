namespace AppleShop.Web.Models;

public class DashboardViewModel
{
    private readonly Dictionary<string, int> _amounts;

    public DashboardViewModel(Dictionary<string, int> amounts)
        => _amounts = amounts;

    public int IPhoneAmount => _amounts["iPhone"];
    public int AppleWatchAmount => _amounts["Apple Watch"];
    public int IPadAmount => _amounts["iPad"];
    public int MacAmount => _amounts["Mac"];
}