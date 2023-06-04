using AppleShop.Product.API.Response;

namespace AppleShop.Product.API.Wrappers;

public class PagedResponse<T> : ApiResponse<T>
{
    public Guid? Id { get; }
    public int PageNumber { get; }
    public int PageSize { get; }
    public int TotalRecords { get; }

    public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);

    public IEnumerable<int> Pages => Enumerable.Range(1, TotalPages);

    public bool HasNextPage => PageNumber < TotalPages;
    public bool HasPreviousPage => PageNumber > 1;

    public int? Color { get; set; }
    public int? MinPrice { get; set; }
    public int? MaxPrice { get; set; }
    public int? Memory { get; set; }

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