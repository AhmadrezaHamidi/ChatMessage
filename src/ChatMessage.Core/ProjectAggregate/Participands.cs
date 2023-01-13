using Ardalis.GuardClauses;
using ChatMessage.Core.ProjectAggregate.Enums;
using ChatMessage.Core.ProjectAggregate.Events;
using ChatMessage.SharedKernel;

namespace ChatMessage.Core.ProjectAggregate;

public class Participands : EntityBase
{
  public string UserId { get; set; } = string.Empty;
  public ParticiSateEnum State { get; set; }
  public DateTime? LastSeenAt { get; private set; }
  public int MessageDidntSeenCount { get; private set; }
  public DateTime LastModiFyState { get; private set; }

  public void MarkComplete()
  {
    
  }

  //public void AddContributor(int contributorId)
  //{
  //  Guard.Against.Null(contributorId, nameof(contributorId));
  //  ContributorId = contributorId;

  //  base.RegisterDomainEvent(contributorAddedToItem);
  //}

  //public void RemoveContributor()
  //{
  //  ContributorId = null;
  //}

  public override string ToString()
  {
    string status = true ? "Done!" : "Not done.";
    return $"{Id}: Status: {status} - {UserId} - {UserId}";
  }
}




public class LastMessage : EntityBase
{
  public string Body { get; set; } = string.Empty;
  public DateTime CreateAt { get; set; }
  public string OwnerName { get; set; } = string.Empty;
}