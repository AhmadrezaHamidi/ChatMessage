using Ardalis.Result;

namespace ChatMessage.Core.Interfaces;

public interface IDeleteContributorService
{
    public Task<Result> DeleteContributor(int contributorId);
}
