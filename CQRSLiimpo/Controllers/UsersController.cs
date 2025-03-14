using CQRSLiimpo.Application.Request;
using CQRSLiimpo.Application.Response;
using CQRSLiimpo.Dispatchers.Command;
using CQRSLiimpo.Domain.Dispatcher.Command;
using CQRSLiimpo.Domain.Dispatcher.Query;
using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Handlers.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace CQRSLiimpo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) : ControllerBase
    {
        private readonly IQueryDispatcher _queryDispatcher = queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher = commandDispatcher;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var query = new GetUserByIdQuery { UserId = id };
            var user = await _queryDispatcher.Dispatch<GetUserByIdQuery, User>(query, cancellationToken);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CriarProduto([FromBody] CreateUserRequest createUser, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createUserResponse = await _commandDispatcher.Dispatch<CreateUserRequest, CreateUserResponse>(createUser, cancellationToken);

            return CreatedAtAction(nameof(CriarProduto), new CreateUserResponse()
            {
                Id = createUserResponse.Id,
                Email = createUserResponse.Email,
                Nome = createUserResponse.Nome
            });
        }

    }
}
