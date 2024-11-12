using CustomerProvider.Interfaces;

namespace CustomerProvider.Models;

public class ResultResponse : BaseResultResponse
{ 
}

public abstract class BaseResultResponse : IBaseResultResponse
{
    public bool Succeeded { get; set; }

    public int StatusCode { get; set; }

    public string? Message { get; set; }
}