using financas.Models;

namespace financas.Response;

public class PagedListResponse<T> : List<T>
{
    public int CurrentPage { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get;  private set; }
    public int TotalCount { get;  private set; }
    public IEnumerable<T> Items { get; set; }
    public bool HasPrevious { get; private set; }
    public bool HasNext { get; private set; }

    public PagedListResponse(IEnumerable<T> items, int count, int pageNumber, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        HasNext = (CurrentPage < TotalPages);
        HasPrevious = CurrentPage > 1;

        Items = items;
    }

    public static PagedListResponse<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
    {
        var count = source.Count();
        var resp = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        return new PagedListResponse<T>(resp, source.Count(), pageNumber, pageSize);
    }
}