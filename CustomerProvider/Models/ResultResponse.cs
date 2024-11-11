namespace CustomerProvider.Models;

public class ResultResponse : BaseResultResponse
{ 
}

public abstract class BaseResultResponse
{
    public bool Succeeded { get; set; }

    public object? Content { get; set; }

    public string? Message { get; set; }
}