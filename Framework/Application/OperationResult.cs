namespace Framework.Application;

public class OperationResult
{
    public bool IsSucceeded { get; set; }
    public string Message { get; set; }
    public object Object { get; set; }

    public OperationResult()
    {
        IsSucceeded = false;
        Message = "Object Created";
        Object = null!;
    }

    public OperationResult Succeeded(object theObject = null!,string message = "عملیات با موفقیت انجام شد")
    {
        IsSucceeded = true;
        Message = message;
        Object = theObject;
        return this;
    }

    public OperationResult Failed(string message)
    {
        IsSucceeded = false;
        Message = message;
        return this;
    }
}