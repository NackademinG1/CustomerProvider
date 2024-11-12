using CustomerProvider.Interfaces;
using CustomerProvider.Models;

namespace CustomerProvider.Factories;

public static class BaseResultResponseFactory
{
    public static IBaseResultResponse Success(int statusCode = 200, string message = null!)
    {
        return new ResultResponse
        {
            Succeeded = true,
            StatusCode = 200,
            Message = message
        };
    }

    public static IBaseResultResponse Failure(int statusCode = 400, string message = null!)
    {
        return new ResultResponse
        {
            Succeeded = false,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static IBaseResultResponse Exists(int statusCode = 409, string message = null!)
    {
        return new ResultResponse
        {
            Succeeded = false,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static IBaseResultResponse NotFound(int statusCode = 404, string message = null!)
    {
        return new ResultResponse
        {
            Succeeded = false,
            StatusCode = statusCode,
            Message = message
        };
    }
}
