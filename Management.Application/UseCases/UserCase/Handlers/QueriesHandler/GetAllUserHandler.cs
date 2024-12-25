using Management.Application.Abstractions;
using Management.Application.Models;
using Management.Application.Password;
using Management.Application.UseCases.UserCase.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.UserCase.Handlers.QueriesHandler;

public class GetAllUserHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IPasswordHasher _hasher;

    public GetAllUserHandler(IApplicationDbContext context, IPasswordHasher hasher)
    {
        _context = context;
        _hasher = hasher;
    }

    public async Task<IEnumerable<UserDto>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _context.Users.AsNoTracking().Select(u => new UserDto
        {
            Id = u.Id,
            FirstName = u.FirstName,
            Phone = u.Phone,
            LastName = u.LastName,
            Email = u.Email,
            CreatedAt = u.CreatedAt,
            UpdatedAt = u.UpdatedAt
        }).ToListAsync(cancellationToken);

        return users;
    }
}
