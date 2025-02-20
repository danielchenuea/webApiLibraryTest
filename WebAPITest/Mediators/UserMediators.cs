using MediatR;
using MediatR.Pipeline;
using WebAPITest.Context;
using WebAPITest.Models;
using WebAPITest.Models.Http;

namespace WebAPITest.Mediators;

public class UserPostCommandHandler : IRequestHandler<UserModel>
{
    private readonly DbContext _context;

    public UserPostCommandHandler(DbContext context)
    {
        _context = context;
    }

    public Task Handle(UserModel request, CancellationToken cancellationToken)
    {
        _context.Users.Add(request);

        return Task.CompletedTask;
    }
}

//public class UserPostCommand_PreProcessor : IRequestPreProcessor<UserPostRequest>
//{
//    public Task Process(UserPostRequest request, CancellationToken cancellationToken)
//    {
//        Console.WriteLine("Preprocessing");
//        return Task.CompletedTask;
//    }
//}

//public class UserPostCommand_PostProcessor : IRequestPostProcessor<UserPostRequest, UserPostResponse>
//{
//    public Task Process(UserPostRequest request, UserPostResponse response, CancellationToken cancellationToken)
//    {
//        Console.WriteLine("Preprocessing");
//        return Task.CompletedTask;
//    }
//}