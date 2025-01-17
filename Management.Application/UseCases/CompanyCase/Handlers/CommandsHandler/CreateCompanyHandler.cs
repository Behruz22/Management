﻿using Management.Application.Abstractions;
using Management.Application.UseCases.CompanyCase.Commands;
using Management.Core.Entities;
using MediatR;

namespace Management.Application.UseCases.CompanyCase.Handlers.CommandsHandler;

public class CreateCompanyHandler : IRequestHandler<CreateCompanyCommand,bool>
{
    private readonly IApplicationDbContext _context;

    public CreateCompanyHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = new Company
        {
            Name = request.Name,
            Address = request.Address,
            Email = request.Email,
            Phone = request.Phone,
            CreatedAt = DateTime.UtcNow
        };

        await _context.Companies.AddAsync(company,cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
