using AppleShop.Web.Services.ModelResponse;
using Newtonsoft.Json;

namespace AppleShop.Web.Services.Wrappers;

public class PagedResponse<T> : ApiResponse<T>
{
    public Guid? Id { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalRecords { get; }

    [JsonIgnore]
    public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

    [JsonIgnore]
    public IEnumerable<int> Pages => Enumerable.Range(1, TotalPages);

    [JsonIgnore]
    public bool HasNextPage => PageNumber < TotalPages;
    [JsonIgnore]
    public bool HasPreviousPage => PageNumber > 1;

    public PagedResponse(Guid? id, T data, int pageNumber, int pageSize, int totalRecords)
    {
        Id = id;

        PageNumber = pageNumber;
        PageSize = pageSize;

        TotalRecords = totalRecords;

        Data = data;
        Succeeded = true;
        Message = null;
    }
}