using System.Text.Json.Serialization;
using CustomerManagement.Application
using CustomerManagement.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
    .AddJsonOptions(options =>
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));


builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    Title = "Customer Management API",
    Version = "v1",
    Description = "A simple CRUD API built with Clean Architecture & ADO.NET."
});

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Customer Management API v1");
    });
}

app.UseHttpsRedirection();



app.MapControllers();

app.Run();
