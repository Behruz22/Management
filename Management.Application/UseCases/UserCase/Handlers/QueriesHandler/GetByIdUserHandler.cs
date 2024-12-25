using Management.Application.Abstractions;
using Management.Application.Models;
using Management.Application.UseCases.UserCase.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.UserCase.Handlers.QueriesHandler;

public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;

    public GetByIdUserHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == request.Id);


        if (user != null)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt
            };
        }
        else
        {
            return null;
        }
    }
}
