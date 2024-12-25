using MediatR;

namespace Management.Application.UseCases.UserCase.Commands;

public class CreateUserCommand : IRequest<bool>
{
    public string? Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
}
