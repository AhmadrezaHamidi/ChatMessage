

namespace ChatMessage.FramWork.Application;

  public interface IQueryBus
  {
      Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query) where TQuery : IQuery;
  }
