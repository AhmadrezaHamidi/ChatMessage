namespace ChatMessage.FramWork.Application;

public class AppException : Exception
{
    public int Code { get; set; }
    public AppException(string message, int errorCode) : base(message)
    {
        Code = errorCode;
    }
}
