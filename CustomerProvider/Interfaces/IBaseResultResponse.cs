namespace CustomerProvider.Interfaces
{
    public interface IBaseResultResponse
    {
        string? Message { get; set; }
        int StatusCode { get; set; }
        bool Succeeded { get; set; }
    }
}