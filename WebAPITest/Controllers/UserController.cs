using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Context;
using WebAPITest.Models;
using WebAPITest.Validators;

namespace WebAPITest.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private ILogger<UserController> _logger;
    private DbContext _dbContext;
    private IMediator _mediator;

    public UserController(ILogger<UserController> logger, DbContext dbContext, IMediator mediator)
    {
        _logger = logger;
        _dbContext = dbContext;
        _mediator = mediator;
    }

    [HttpGet(Name = "GetDummyUser")]
    public IActionResult GetDummyUser()
    {
        return Ok(_dbContext.Users.FirstOrDefault());
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

        _mediator.Send(dummyUser);

        return NoContent();
    }
}
