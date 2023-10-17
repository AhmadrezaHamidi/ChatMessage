

namespace ChatMessage.FramWork.Application.CQRS.Command
{
    public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery
    {
        Task<TQueryResult> Handle(TQuery query);
    }
}
