using MediatorDDD.Cadastro.Commands;
using MediatorDDD.Cadastro.Service;
using Microsoft.AspNetCore.Mvc;
using MediatorDDD.SharedKernel.Extensions;
using MediatorDDD.SharedKernel.Interfaces;
using MediatorDDD.SharedKernel.Implementation;
using MediatorDDD.SharedKernel.Events;
using MediatorDDD.Cadastro.Handlers;
using MediatorDDD.Financeiro.Handlers;
using MediatorDDD.Crm.Handlers;
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<IClienteService, ClienteService>();

// REGISTRO DO MEDIATOR

// Mais performatico
//builder.Services.AddSimpleMediator("Cadastro", "Crm", "Financeiro", "SharedKernel");

// Mais custoso
//builder.Services.AddSimpleMediator();
//builder.Services.AddSimpleMediator(AppDomain.CurrentDomain.GetAssemblies());

// Mais trabalhoso
services.AddSingleton<IMediator, Mediator>();
services.AddTransient<IRequestHandler<CadastrarClienteCommand, string>, ClienteHandler>();
services.AddTransient<IRequestHandler<ExcluirClienteCommand, bool>, ClienteHandler>();
services.AddTransient<INotificationHandler<ClienteCadastradoEvent>, GestaoContaHandler>();
services.AddTransient<INotificationHandler<ClienteCadastradoEvent>, NotificadorHandler>();
services.AddTransient<INotificationHandler<ClienteExcluidoEvent>, GestaoContaHandler>();
services.AddTransient<INotificationHandler<ClienteExcluidoEvent>, NotificadorHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/cadastrar", async ([FromBody] CadastrarClienteCommand command, IClienteService service) =>
{
    var resultado = await service.CadastrarCliente(command);
    return Results.Ok(resultado);
}).WithName("CadastrarCliente")
  .WithTags("Clientes");

app.MapPost("/excluir", async ([FromBody] ExcluirClienteCommand command, IClienteService service) =>
{
    var resultado = await service.ExcluirCliente(command);

    if (!resultado)
        return Results.BadRequest($"Problema ao excluir o cliente {command.Id}");

    return Results.Ok(command.Id);

}).WithName("ExcluirCliente")
  .WithTags("Clientes");

app.Run();