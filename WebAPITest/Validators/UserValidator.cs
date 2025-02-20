using FluentValidation;
using WebAPITest.Models;

namespace WebAPITest.Validators;

public class UserValidator : AbstractValidator<UserModel>
{
    public UserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithErrorCode("E1").WithMessage("Não pode ser vazio")
            .NotEqual(Guid.Empty).WithErrorCode("GE1").WithMessage("O Guid não pode ser vazio");
        
        RuleForEach(x => x.Permissions)
            .NotEmpty().WithErrorCode("E1").WithMessage("Não pode ser vazio")
            .NotNull().WithErrorCode("N2").WithMessage("Não pode ser nulo");

        RuleFor(x => x.Address).SetValidator(new AddressValidator());

        RuleFor(x => x.Email).EmailAddress();
    }
}

public class AddressValidator : AbstractValidator<AddressModel>
{
    public AddressValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithErrorCode("E1").WithMessage("Não pode ser vazio")
            .NotEqual(Guid.Empty).WithErrorCode("GE1").WithMessage("O Guid não pode ser vazio");

        RuleFor(x => x.Postcode)
            .NotEmpty().WithErrorCode("E1").WithMessage("Não pode ser vazio");
    }
}