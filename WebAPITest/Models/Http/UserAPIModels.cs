using MediatR;

namespace WebAPITest.Models.Http;

public class UserPostRequest
{
    public UserModel? User { get; set; }
}

public class UserPostResponse<T>
{
    public UserPostResponse(string message, bool success, T? data)
    {
        Message = message;
        Success = success;
        Data = data;
    }

    public string Message { get; set; }
    public bool Success { get; set; }
    public T? Data { get; set; }
}
