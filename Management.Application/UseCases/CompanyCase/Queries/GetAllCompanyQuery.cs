using Management.Application.Models;
using MediatR;

namespace Management.Application.UseCases.CompanyCase.Queries;

public class GetAllCompanyQuery : IRequest<IQueryable<CompanyDto>>
{

}
