using MediatR.Pipeline;
using WebAPITest.Models.Http;

namespace WebAPITest.Mediators;

public class UserPost_PreProcessor : IRequestPreProcessor<UserPostRequest>
{
    public Task Process(UserPostRequest request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Preprocessing");
        return Task.CompletedTask;
    }
}

public class UserPost_PostProcessor : IRequestPostProcessor<UserPostRequest, UserPostResponse>
{
    public Task Process(UserPostRequest request, UserPostResponse response, CancellationToken cancellationToken)
    {
        Console.WriteLine("Preprocessing");
        return Task.CompletedTask;
    }
}