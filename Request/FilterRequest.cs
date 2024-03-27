namespace financas.Request;

public class FilterRequest
{ 
    const int  MaxPerPage = 50;
    public int Page { get; set; } = 1;
    private int _pageSize;

    public int PageSize
    {
        get => _pageSize;
        set
        {
            _pageSize = (value > MaxPerPage) ? MaxPerPage : value;
        } 
    }
}