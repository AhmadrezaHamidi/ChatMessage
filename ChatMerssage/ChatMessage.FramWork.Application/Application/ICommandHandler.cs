

namespace ChatMessage.FramWork.Application;

  public interface ICommandHandler<in T> where T : ICommand
  {
      Task<CommandResult> Handle(T command);
  }
