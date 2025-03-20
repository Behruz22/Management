using Management.Application.UseCases.CompanyCase.Commands;
using Management.Application.UseCases.CompanyCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class CompaniesController(IMediator _mediator): ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllCompanyQuery());

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetByIdCompanyQuery
        {
            Id = id
        });

        return Ok(result);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create(CreateCompanyCommand company)
    {
        var result = await _mediator.Send(company);

        return Ok(result);
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update(UpdateCompanyCommand company)
    {
        var result = await _mediator.Send(company);

        return Ok(result);
    }

    [HttpDelete]
    public async ValueTask<IActionResult> Delete(int Id)
    {
        var result = await _mediator.Send(new DeleteCompanyCommand
        {
            Id = Id
        });

        return Ok(result);
    }
}
