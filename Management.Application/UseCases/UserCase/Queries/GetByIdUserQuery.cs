using Management.Application.Models;
using MediatR;

namespace Management.Application.UseCases.UserCase.Queries;

public class GetByIdUserQuery : IRequest<UserDto>
{
    public int Id { get; set; }
}
