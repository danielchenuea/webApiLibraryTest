namespace WebAPITest.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public AddressModel Address { get; set; } = new ();
    public List<string> Permissions { get; set; } = [];

    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string UsernameHash { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string EmailHash { get; set; } = string.Empty;
}

public class AddressModel {
    public Guid Id { get; set; }
    public string Postcode { get; set; } = string.Empty;
}