using Management.Application.Abstractions;
using Management.Application.Password;
using Management.Application.UseCases.UserCase.Commands;
using Management.Core.Entities;
using MediatR;

namespace Management.Application.UseCases.UserCase.Handlers.CommandsHandler;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
{

    private readonly IApplicationDbContext _context;
    private readonly IPasswordHasher _hasher;

    public CreateUserHandler(IApplicationDbContext context, IPasswordHasher hasher)
    {
        _context = context;
        _hasher = hasher;
    }

    public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            CreatedAt = DateTime.UtcNow,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Phone = request.Phone,
            PasswordHash = _hasher.HashPassword(request.Password)
        };

        await _context.Users.AddAsync(user,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return true;
    }
}
