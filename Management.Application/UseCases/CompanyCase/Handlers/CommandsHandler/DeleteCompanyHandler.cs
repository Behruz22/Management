using Management.Application.Abstractions;
using Management.Application.UseCases.CompanyCase.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Management.Application.UseCases.CompanyCase.Handlers.CommandsHandler;

public class DeleteCompanyHandler(IApplicationDbContext _context) : IRequestHandler<DeleteCompanyCommand,bool>
{
    public async Task<bool> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _context.Companies.FirstOrDefaultAsync(c => c.Id == request.Id);

        if (company != null)
        {
            _context.Companies.Remove(company);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}
