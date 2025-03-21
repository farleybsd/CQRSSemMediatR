﻿using CQRSLiimpo.Application.Request;
using CQRSLiimpo.Application.Response;
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

        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> CriarCliente([FromBody] CreateUserRequest createUser, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createUserResponse = await _commandDispatcher.Dispatch<CreateUserRequest, CreateUserResponse>(createUser, cancellationToken);

            return CreatedAtAction(nameof(CriarCliente), new CreateUserResponse()
            {
                Id = createUserResponse.Id,
                Email = createUserResponse.Email,
                Nome = createUserResponse.Nome
            });
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreateUserResponse>>> BuscarTodosClientes(CancellationToken cancellationToken)
        {
            var createUserRequest = await _queryDispatcher.DispatchAll(cancellationToken);

            if (createUserRequest == null || !createUserRequest.Any())
            {
                return NotFound();
            }

            return Ok(createUserRequest);
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete(DeleteUserRequest deleteUserRequest, CancellationToken cancellationToken)
        {
            var messegeResult = await _queryDispatcher.DispatchDelete<DeleteUserRequest, string>(deleteUserRequest, cancellationToken);

            if (messegeResult == null)
            {
                return NotFound();
            }
            return messegeResult;
        }

        [HttpPut]
        public async Task<IActionResult> AlterarCliente([FromBody] UpdateUserRequest updateUserRequest, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ValidationProblemDetails(ModelState));

            try
            {
                var createUserResponse = await _commandDispatcher.Dispatch<UpdateUserRequest, CreateUserResponse>(updateUserRequest, cancellationToken);

                if (createUserResponse is null)
                    return NotFound("Usuário não encontrado ou não foi possível atualizar.");

                return Ok(createUserResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro interno ao processar a solicitação.", error = ex.Message });
            }
        }
    }
}