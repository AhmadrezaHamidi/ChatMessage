namespace ChatMessage.FramWork.Application;

public class PagingQueryResult<T> : IQueryResult where T : class
{
    public int PageSize { get; set; }
    public long Count { get; set; }
    public PagingQueryResult(T queryView, int pageSize, long count) 
    {
        PageSize = pageSize;
        Count = count;
    }
}
