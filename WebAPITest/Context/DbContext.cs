using WebAPITest.Models;

namespace WebAPITest.Context;

public class DbContext
{
    public List<UserModel> Users { get; set; }

    public DbContext()
    {
        Users = new List<UserModel>() {
            new UserModel()
            {
                Id = Guid.NewGuid(),
                Username = "test",
                Email = "test@test.com",
                Permissions = new[] { "Test" }.ToList()

            }
        };
    }
}
