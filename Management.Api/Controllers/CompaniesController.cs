using Management.Application.UseCases.CompanyCase.Commands;
using Management.Application.UseCases.CompanyCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Management.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly IMediator _mediator;
    public CompaniesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAll()
    {
        try
        {
            var result = await _mediator.Send(new GetAllCompanyQuery());
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred");
        }
    }

    [HttpGet("{id}")]
    public async ValueTask<IActionResult> GetById(int id)
    {
        try
        {
            var result = await _mediator.Send(new GetByIdCompanyQuery { Id = id });
            if (result == null)
                return NotFound($"Company with ID {id} not found");
                
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred");
        }
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] CreateCompanyCommand company)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(company);
            return StatusCode(201, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred");
        }
    }

    [HttpPut("{id}")]
    public async ValueTask<IActionResult> Update(int id, [FromBody] UpdateCompanyCommand company)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != company.Id)
                return BadRequest("ID mismatch");

            var result = await _mediator.Send(company);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred");
        }
    }

    [HttpDelete("{id}")]
    public async ValueTask<IActionResult> Delete(int id)
    {
        try
        {
            await _mediator.Send(new DeleteCompanyCommand { Id = id });
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred");
        }
    }
}