using MediatR;
using Microsoft.EntityFrameworkCore;
using UserCQRST.Data;
using UserCQRST.Data.Entities;
using UserCQRSTemplate.Features.Users.Command.CreateUser;

namespace UserCQRST.Features.Users.Command.CreateUser 
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly AppDbContext _dbContext;

        public CreateUserCommandHandler(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var emailExists = await _dbContext.Users.AnyAsync(u => u.Email == request.Email);
            if (emailExists)
            {
                throw new InvalidOperationException($"User with email '{request.Email}' already exists");
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                Email = request.Email,
                Role = request.Role,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}