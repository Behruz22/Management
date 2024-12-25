using Management.Application.Models;
using MediatR;

namespace Management.Application.UseCases.CompanyCase.Queries;

public class GetByIdCompanyQuery : IRequest<CompanyDto>
{
    public int Id { get; set; }
}
