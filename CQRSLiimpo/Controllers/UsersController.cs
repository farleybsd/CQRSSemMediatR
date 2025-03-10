using CQRSLiimpo.Domain.Dispatcher.Command;
using CQRSLiimpo.Domain.Dispatcher.Query;
using CQRSLiimpo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

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
    }
}
