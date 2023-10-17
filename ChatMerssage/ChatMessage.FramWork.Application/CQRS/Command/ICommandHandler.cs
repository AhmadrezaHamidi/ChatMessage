namespace ChatMessage.FramWork.Application.CQRS.Command
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task<CommandResult> Handle(T command);
    }
}
