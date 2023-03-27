using AppleShop.Web.RetryPolicies.Config;
using Polly;
using Polly.Retry;

namespace AppleShop.Web.RetryPolicies;

public static class HttpRetryPolicies
{
    public static AsyncRetryPolicy<HttpResponseMessage> GetHttpRetryPolicy(IRetryPolicyConfig retryPolicyConfig)
        => HttpPolicyBuilders
            .GetBaseBuilder()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(retryPolicyConfig.RetryCount,
                                ComputeDuration);

    private static TimeSpan ComputeDuration(int input)
    {
        return TimeSpan.FromSeconds(Math.Pow(2, input)) + TimeSpan.FromMilliseconds(new Random().Next(0, 100));
    }
}