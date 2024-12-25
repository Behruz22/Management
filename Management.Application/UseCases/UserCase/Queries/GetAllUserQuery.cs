using Management.Application.Models;
using MediatR;

namespace Management.Application.UseCases.UserCase.Queries;

public class GetAllUserQuery : IRequest<IEnumerable<UserDto>>
{
}
