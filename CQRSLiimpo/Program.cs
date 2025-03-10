using CQRSLiimpo.Controllers;
using CQRSLiimpo.Dispatchers.Command;
using CQRSLiimpo.Dispatchers.Query;
using CQRSLiimpo.Domain.Dispatcher.Command;
using CQRSLiimpo.Domain.Dispatcher.Query;
using CQRSLiimpo.Domain.Entities;
using CQRSLiimpo.Domain.Queries;
using CQRSLiimpo.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IQueryDispatcher, QueryDispatcher>();
builder.Services.AddTransient<ICommandDispatcher, CommandDispatcher>();
// Registro do QueryHandler
builder.Services.AddScoped<IQueryHandler<GetUserByIdQuery, User>, GetUserByIdQueryHandler>();
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
