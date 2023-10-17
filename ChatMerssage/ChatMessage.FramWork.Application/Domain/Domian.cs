using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMessage.FramWork.Domain;

public abstract class Entity<TKey>
{
  public TKey Id { get;protected set; }
}



public abstract class AggrigateRoot<TKey>  : Entity<TKey>
{
}


internal class Domian
{
}
