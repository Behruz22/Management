using Management.Application.Abstractions;
using Management.Application.UseCases.UserCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.UserCase.Handlers.CommandsHandler;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
{
    private readonly IApplicationDbContext _context;

    public DeleteUserHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}
