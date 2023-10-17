namespace ChatMessage.FramWork.Application.CQRS.Command
{
    public interface ICommandBus
    {
        Task<CommandResult> Dispatch<T>(T command) where T : ICommand;
    }
}
