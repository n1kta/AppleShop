using AppleShop.Web.RetryPolicies;
using AppleShop.Web.RetryPolicies.Config;

namespace AppleShop.Web.Extensions;

public static class HttpClientBuilderExtensions
{
    public static IHttpClientBuilder AddPolicyHandlers(this IHttpClientBuilder clientBuilder,
        string policySectionName,
        IConfiguration configuration)
    {
        var policyConfig = new PolicyConfig();
        configuration.Bind(policySectionName, policyConfig);

        var retryPolicyConfig = (IRetryPolicyConfig) policyConfig;
        var circuitBreakerPolicyConfig = (ICircuitBreakerPolicyConfig) policyConfig;

        return clientBuilder
            .AddRetryPolicyHandler(retryPolicyConfig)
            .AddCircuitBreakerHandler(circuitBreakerPolicyConfig);
    }

    public static IHttpClientBuilder AddRetryPolicyHandler(this IHttpClientBuilder httpClientBuilder, IRetryPolicyConfig retryPolicyConfig)
    {
        return httpClientBuilder.AddPolicyHandler(HttpRetryPolicies.GetHttpRetryPolicy(retryPolicyConfig));
    }

    public static IHttpClientBuilder AddCircuitBreakerHandler(this IHttpClientBuilder httpClientBuilder, ICircuitBreakerPolicyConfig circuitBreakerPolicyConfig)
    {
        return httpClientBuilder.AddPolicyHandler(HttpCircuitBreakerPolicies.GetHttpCircuitBreakerPolicy(circuitBreakerPolicyConfig));
    }
}