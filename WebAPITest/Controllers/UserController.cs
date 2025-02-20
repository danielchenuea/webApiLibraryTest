using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;
using WebAPITest.Validators;

namespace WebAPITest.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private ILogger<UserController> _logger;
    private IMediator _mediator;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetDummyUser")]
    public IActionResult GetDummyUser()
    {
        return Ok(new UserModel()
        {
            Id = Guid.NewGuid(),
            Username = "test",
            Email = "test@test.com",
            Permissions = new[] { "Test" }.ToList()

        });
    }

    [HttpPost(Name = "PostDummyUser")]
    public IActionResult PostDummyUser([FromBody] UserModel dummyUser)
    {
        UserValidator validator = new();
        ValidationResult validationResult = validator.Validate(dummyUser);

        if (!validationResult.IsValid)
        {
            var error = validationResult.Errors.First();
            return BadRequest($"{error.ErrorCode} - {error.ErrorMessage}");
        }

        return NoContent();
    }
}
