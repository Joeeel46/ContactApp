using ContactApp.Business;
using ContactApp.Data.Service;
using ContactMS.Data;
using ContactApp.DTO.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddServices();

// Register data services
builder.Services.AddDataServices();

// Register entities, UnitOfWork, DbContext
builder.Services.AddEntities();

// Register DTO mappers
builder.Services.AddDTOMappers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
