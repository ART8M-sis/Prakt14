using MediatR;
using UserCQRST.Data;
using UserCQRST.Features.Users.Command.DeleteUser;

namespace UserCQRSTemplate.Features.Users.Command.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly AppDbContext _appDbContext;

        public DeleteUserCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _appDbContext.Users.FindAsync(new object[] { request.Id }, cancellationToken);
            if (user == null)
            {
                return false;
            }

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}