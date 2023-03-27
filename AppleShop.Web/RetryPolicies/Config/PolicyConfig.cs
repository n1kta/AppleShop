namespace AppleShop.Web.RetryPolicies.Config;

public class PolicyConfig : IRetryPolicyConfig, ICircuitBreakerPolicyConfig
{
    public int RetryCount { get; set; }
    public int BreakDuration { get; set; }
}