namespace ChatMessage.FramWork.Application.CQRS.Command;

public class PagingQuery : IQuery
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}