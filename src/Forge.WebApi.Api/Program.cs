using FastEndpoints;
using FastEndpoints.Swagger;
using Forge.WebApi.Api.DependencyInjection;
using Forge.WebApi.Api.Exceptions;

var builder = WebApplication.CreateBuilder(args);
builder.AddDatabase();

builder.Services.ConfigureDI();
builder.Services
    .AddFastEndpoints(options => options.IncludeAbstractValidators = true)
    .SwaggerDocument();

var app = builder.Build();

app.UseExceptionFilter();

app.UseHttpsRedirection();
app.UseFastEndpoints();
app.UseSwaggerGen();


app.Run();

