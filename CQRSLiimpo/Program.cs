using CQRSLiimpo.Application.Request;
using CQRSLiimpo.Application.Response;
using CQRSLiimpo.Controllers;
using CQRSLiimpo.Dispatchers.Command;
using CQRSLiimpo.Dispatchers.Query;
using CQRSLiimpo.Domain.Command;
using CQRSLiimpo.Domain.Dispatcher.Command;
using CQRSLiimpo.Domain.Dispatcher.Query;
using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Queries;
using CQRSLiimpo.Domain.Repositories;
using CQRSLiimpo.Handlers;
using CQRSLiimpo.Handlers.Commands;
using CQRSLiimpo.Handlers.Queries;
using CQRSLiimpo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IQueryDispatcher, QueryDispatcher>();
builder.Services.AddTransient<ICommandDispatcher, CommandDispatcher>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

// Registro do QueryHandler
builder.Services.AddScoped<IQueryHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
builder.Services.AddScoped<ICommandHandler<CreateUserRequest, CreateUserResponse>, CreateUserCommandHandler>();
// Registro do QueryHandlerAll
builder.Services.AddScoped<IQueryGetAllHandler<IEnumerable<CreateUserResponse>>, GetUserAllQueryHandler>();

builder.Services.AddScoped<IDeleteHandler<DeleteUserRequest, string>, DeleteUserCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateUserRequest, CreateUserResponse>, UpdateUserCommandHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();