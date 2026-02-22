using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();   // Provides Swagger with information about available endpoints
builder.Services.AddSwaggerGen();              // Generates interactive documentation and allows API testing via Swagger UI

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();    // Generates the JSON specification of the API
    app.UseSwaggerUI();  // Enables interaction with the API via Swagger UI
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
