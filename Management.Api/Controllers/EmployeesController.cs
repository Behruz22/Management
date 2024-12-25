using Management.Application.UseCases.EmployeeCase.Commands;
using Management.Application.UseCases.EmployeeCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GettAll()
        {
            var result = await _mediator.Send(new GetAllEmployeeQuery());

            return Ok(result);
        }

        [HttpGet("id")]
        public async ValueTask<IActionResult> GetById(int Id)
        {
            var result = await _mediator.Send(new GetByIdEmployeeQuery
            {
                Id = Id
            });

            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create(CreateEmployeeCommand employee)
        {
            var result = await _mediator.Send(employee);

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update(UpdateEmployeeCommand employee)
        {
            var result = await _mediator.Send(employee);

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> Delete(int Id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand
            {
                Id = Id
            });

            return Ok(result);
        }
    }
}
