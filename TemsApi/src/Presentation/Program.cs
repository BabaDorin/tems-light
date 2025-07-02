using Application;
using Application.AssetDefinitions.Commands;
using Application.Assets.Commands;
using Application.AssetTypes.Commands;
using Domain.Entities;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/types", async (ISender sender, [FromBody] AssetType assetType, CancellationToken cancellationToken) =>
{
    var type = await sender.Send(new CreateTypeCommand(assetType), cancellationToken);

    return type;
});

app.MapPost("/definitions", async (ISender sender, [FromBody] AssetDefinition assetDefinition, CancellationToken cancellationToken) =>
{
    var definition = await sender.Send(new CreateDefinitionCommand(assetDefinition), cancellationToken);

    return definition;
});

app.MapPost("/assets", async (ISender sender, [FromBody] Asset asset, CancellationToken cancellationToken) =>
{
    var createdAsset = await sender.Send(new CreateAssetCommand(asset), cancellationToken);

    return createdAsset;
});

app.UseHttpsRedirection();


app.Run();
