

namespace ChatMessage.FramWork.Application.CQRS.Command
{
    public interface IQueryBus
    {
        Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery;
    }
}
