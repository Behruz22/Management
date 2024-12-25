using MediatR;

namespace Management.Application.UseCases.UserCase.Commands;

public class DeleteUserCommand : IRequest<bool>
{
    public int Id { get; set; }
}
