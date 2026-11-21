using MediatR;

namespace UserCQRST.Features.Users.Command.DeleteUser
{
    public record DeleteUserCommand(Guid Id) : IRequest<bool>;

}
