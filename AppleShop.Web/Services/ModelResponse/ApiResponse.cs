using Newtonsoft.Json;

namespace AppleShop.Web.Services.ModelResponse;

public class ApiResponse<T>
{
    [JsonProperty("data")]
    public T? Data { get; protected set; }

    [JsonProperty("succeeded")]
    public bool Succeeded { get; protected set; }

    [JsonProperty("message")]
    public string? Message { get; protected set; }

    public static ApiResponse<T> Fail(string message)
        => new ApiResponse<T> { Succeeded = false, Message = message };

    public static ApiResponse<T> Success(T data)
        => new ApiResponse<T> { Succeeded = true, Data = data };
}