using MediatR;

namespace Management.Application.UseCases.CompanyCase.Commands;

public class DeleteCompanyCommand : IRequest<bool>
{
    public int Id { get; set; }
}
