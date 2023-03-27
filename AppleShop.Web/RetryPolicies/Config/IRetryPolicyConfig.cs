namespace AppleShop.Web.RetryPolicies.Config;

public interface IRetryPolicyConfig
{
    int RetryCount { get; set; }
}