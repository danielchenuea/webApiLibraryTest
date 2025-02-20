using MediatR;

namespace WebAPITest.Models.Http;

public class UserPostRequest: IRequest<UserPostResponse>
{
    public UserModel? User { get; set; }
}

public class UserPostResponse
{
    
}
