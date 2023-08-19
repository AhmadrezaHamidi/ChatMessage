using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Domain.Base;

namespace Domain.UserAggregate;



public class UserAggregate : AggregateRoot<UserId>
{
  public string FirstName { get;private set; }
  public string UserName { get; private set; }
  public string? UrlAvatar { get; private set; }
  public CustomerAddress Address { get; private set; }

  private UserAggregate(string firstName, string userName, string? urlAvatar, CustomerAddress address)
  {
    FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
    UserName = userName;
    UrlAvatar = urlAvatar;
    Address = address;
  }






  //private readonly List<ToDoItem> _items = new();
  //public IEnumerable<ToDoItem> Items => _items.AsReadOnly();
  //public ProjectStatus Status => _items.All(i => i.IsDone) ? ProjectStatus.Complete : ProjectStatus.InProgress;

  //public PriorityStatus Priority { get; }

  //public UserAggregate(string name, PriorityStatus priority)
  //{
  //  Name = Guard.Against.NullOrEmpty(name, nameof(name));
  //  Priority = priority;
  //}

  //public void AddItem(ToDoItem newItem)
  //{
  //  Guard.Against.Null(newItem, nameof(newItem));
  //  _items.Add(newItem);

  //  var newItemAddedEvent = new NewItemAddedEvent(this, newItem);
  //  base.RegisterDomainEvent(newItemAddedEvent);
  //}

  //public void UpdateName(string newName)
  //{
  //  Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
  //}
}
