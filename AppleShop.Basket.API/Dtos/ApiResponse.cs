namespace AppleShop.Basket.API.Dtos;

public class ApiResponse<T>
{
    public T? Data { get; protected set; }

    public bool Succeeded { get; protected set; }

    public string? Message { get; protected set; }

    public static ApiResponse<T> Fail(string message)
        => new ApiResponse<T> { Succeeded = false, Message = message };

    public static ApiResponse<T> Success(T data)
        => new ApiResponse<T> { Succeeded = true, Data = data };
}