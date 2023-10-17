using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ChatMessage.FramWork.Application;

namespace ChatMessage.FramWork.AutoFact;
internal class AuthoFactCommandBus : ICommandBus
{
  public ILifetimeScope LifetimeScope { get; }

  public AuthoFactCommandBus(ILifetimeScope lifetimeScope)
  {
    LifetimeScope = lifetimeScope;
  }


  public async Task<CommandResult> Dispatch<T>(T command) where T : ICommand
  {
    var handlers = LifetimeScope.Resolve<ICommandHandler<T>>();
     return await handlers.Handle(command);
  }
}
