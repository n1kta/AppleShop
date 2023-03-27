using Polly;
using Polly.Extensions.Http;

namespace AppleShop.Web.RetryPolicies;

public static class HttpPolicyBuilders
{
    public static PolicyBuilder<HttpResponseMessage> GetBaseBuilder()
        => HttpPolicyExtensions.HandleTransientHttpError();
}