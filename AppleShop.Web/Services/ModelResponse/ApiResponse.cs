using Newtonsoft.Json;

namespace AppleShop.Web.Services.ModelResponse;

public class ApiResponse<T>
{
    [JsonProperty("data")]
    public T? Data { get; private set; }

    [JsonProperty("succeeded")]
    public bool Succeeded { get; private set; }

    [JsonProperty("message")]
    public string? Message { get; private set; }

    public static ApiResponse<T> Fail(string message)
        => new ApiResponse<T> { Succeeded = false, Message = message };

    public static ApiResponse<T> Success(T data)
        => new ApiResponse<T> { Succeeded = true, Data = data };
}