using FluentValidation;

namespace UserCQRSTemplate.Features.Users.Command.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(50).WithMessage("Max lenght 50 simbols");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid format for email");

            RuleFor(x => x.Role)
                .Must(r => r is "User" or "Admin")
                .WithMessage("Role must be User or Admin");
        }
    }
}