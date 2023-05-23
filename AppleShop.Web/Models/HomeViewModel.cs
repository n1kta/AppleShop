namespace AppleShop.Web.Models;

public class HomeViewModel
{
    public DashboardViewModel Dashboard { get; }

    public HomeViewModel(Dictionary<string, int> amounts)
    {
        Dashboard = new DashboardViewModel(amounts);
    }
}