using Management.Application.Abstractions;
using Management.Application.Password;
using Management.Application.UseCases.UserCase.Commands;
using MediatR;

namespace Management.Application.UseCases.UserCase.Handlers.CommandsHandler;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, bool>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordHasher _hasher;

    public UpdateUserHandler(IApplicationDbContext context, IPasswordHasher hasher = null)
    {
        _context = context;
        _hasher = hasher;
    }

    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = _context.Users.FirstOrDefault(c => c.Id == request.Id);

        if (user != null)
        {
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.UpdatedAt = DateTime.UtcNow;
            user.Phone = request.Phone;
            user.PasswordHash = _hasher.HashPassword(request.Password);

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}
