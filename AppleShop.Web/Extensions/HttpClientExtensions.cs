using AppleShop.Web.Services.ModelResponse;
using Newtonsoft.Json;

namespace AppleShop.Web.Extensions;

public static class HttpClientExtensions
{
    #region ApiResponse

    public static async Task<TResponse> GetRequestAsync<T, TResponse>(this HttpClient httpClient, string url)
        where T : ApiResponse<TResponse>
    {
        var responseString = await httpClient.GetStringAsync(url);

        var apiResponse = JsonConvert.DeserializeObject<T>(responseString);

        if (apiResponse == null || (apiResponse != null && !apiResponse.Succeeded))
            return default;

        var data = apiResponse.Data;

        return data;
    }

    public static async Task<TResponse?> PostRequestAsync<T, TRequest, TResponse>(this HttpClient httpClient,
        string url,
        TRequest request)
        where T : ApiResponse<TResponse?>
        where TRequest : class
    {
        var body = JsonConvert.SerializeObject(request);

        var responseString = await httpClient.PostAsJsonAsync(url, body);
        var content = await responseString.Content.ReadAsStringAsync();

        var apiResponse = JsonConvert.DeserializeObject<T>(content);

        if (apiResponse == null || (apiResponse != null && !apiResponse.Succeeded))
            return default;

        var data = apiResponse.Data;

        return data;
    }

    public static async Task<TResponse?> UpdateRequestAsync<T, TRequest, TResponse>(this HttpClient httpClient,
        string url,
        TRequest request)
        where T : ApiResponse<TResponse?>
        where TRequest : class
    {
        var body = JsonConvert.SerializeObject(request);

        var responseString = await httpClient.PutAsJsonAsync(url, body);
        var content = await responseString.Content.ReadAsStringAsync();

        var apiResponse = JsonConvert.DeserializeObject<T>(content);

        if (apiResponse == null || (apiResponse != null && !apiResponse.Succeeded))
            return default;

        var data = apiResponse.Data;

        return data;
    }

    public static async Task<TResponse?> DeleteRequestAsync<T, TResponse>(this HttpClient httpClient, string url)
        where T : ApiResponse<TResponse?>
    {
        var responseString = await httpClient.DeleteAsync(url);
        var content = await responseString.Content.ReadAsStringAsync();

        var apiResponse = JsonConvert.DeserializeObject<T>(content);

        if (apiResponse == null || (apiResponse != null && !apiResponse.Succeeded))
            return default;

        var data = apiResponse.Data;

        return data;
    }

    #endregion

    #region PagedResponse

    public static async Task<Services.Wrappers.PagedResponse<T>> GetPagedRequestAsync<T>(this HttpClient httpClient, string url)
    {
        var responseString = await httpClient.GetStringAsync(url);

        var apiResponse = JsonConvert.DeserializeObject<Services.Wrappers.PagedResponse<T>>(responseString);

        if (apiResponse == null || (apiResponse != null && !apiResponse.Succeeded))
            return default;

        return apiResponse;
    }

    #endregion
}