using MediatR;

namespace UserCQRSTemplate.Features.Users.Command.CreateUser
{
    public record CreateUserCommand(
        string FirstName,
        string Email,
        string Role
    ) : IRequest<Guid>;
}