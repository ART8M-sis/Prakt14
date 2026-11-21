using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCQRST.Data;
using UserCQRST.Data.Entities;

namespace UserCQRST.Features.Users.Query.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
    {
        private readonly AppDbContext _appDbContext;

        public GetAllUsersHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext.Users
                .AsNoTracking()
                .Select(u => new UserDto(
                    u.Id,
                    u.FirstName,
                    u.Email,
                    u.Role,
                    u.CreatedAt
                ))
                .ToListAsync(cancellationToken);
        }
    }
}