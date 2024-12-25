using Management.Application.UseCases.CompanyCase.Queries;
using Management.Application.UseCases.UserCase.Commands;
using Management.Application.UseCases.UserCase.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Management.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GettAll()
        {
            var result = await _mediator.Send(new GetAllUserQuery());

            return Ok(result);

        }

        [HttpGet("id")]
        public async ValueTask<IActionResult> GetById(int Id)
        {
            var result = await _mediator.Send(new GetByIdUserQuery
            {
                Id = Id
            });

            return Ok(result);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create(CreateUserCommand user)
        {
            var result = await _mediator.Send(user);

            return Ok(result);
        }

        [HttpPut]
        public async ValueTask<IActionResult> Update(UpdateUserCommand user)
        {
            var result = await _mediator.Send(user);

            return Ok(result);
        }

        [HttpDelete]
        public async ValueTask<IActionResult> Delete(int Id)
        {
            var result = await _mediator.Send(new DeleteUserCommand
            {
                Id = Id
            });

            return Ok(result);
        }
    }
}
