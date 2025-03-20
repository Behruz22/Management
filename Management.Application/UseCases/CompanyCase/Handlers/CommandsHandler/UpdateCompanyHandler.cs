using Management.Application.Abstractions;
using Management.Application.UseCases.CompanyCase.Commands;
using MediatR;

namespace Management.Application.UseCases.CompanyCase.Handlers.CommandsHandler;

public class UpdateCompanyHandler(IApplicationDbContext _context) : IRequestHandler<UpdateCompanyCommand, bool>
{
    public async Task<bool> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = _context.Companies.FirstOrDefault(c => c.Id == request.Id);
        if (company != null)
        {
            company.Name = request.Name;
            company.Address = request.Address;
            company.UpdatedAt = DateTime.UtcNow;
            company.Phone = request.Phone;
            company.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

       return false;
    }
}
