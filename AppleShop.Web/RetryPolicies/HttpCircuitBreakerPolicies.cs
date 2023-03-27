using AppleShop.Web.RetryPolicies.Config;
using Polly;
using Polly.CircuitBreaker;

namespace AppleShop.Web.RetryPolicies;

public class HttpCircuitBreakerPolicies
{
    public static AsyncCircuitBreakerPolicy<HttpResponseMessage> GetHttpCircuitBreakerPolicy(ICircuitBreakerPolicyConfig circuitBreakerPolicyConfig)
        => HttpPolicyBuilders
            .GetBaseBuilder()
            .CircuitBreakerAsync(circuitBreakerPolicyConfig.RetryCount + 1,
                TimeSpan.FromSeconds(circuitBreakerPolicyConfig.BreakDuration));
}