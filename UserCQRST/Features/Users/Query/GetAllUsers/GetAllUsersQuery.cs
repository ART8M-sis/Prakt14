using MediatR;
using UserCQRST.Data.Entities;

namespace UserCQRST.Features.Users.Query.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<IEnumerable<UserDto>>;
}
