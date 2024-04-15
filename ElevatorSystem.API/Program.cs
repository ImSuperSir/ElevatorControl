using ElevatorSystem.Application;
using ElevatorSystem.Domain.Entities;
using ElevatorSystem.Domain.Interfaces;
using ElevatorSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args); // Create a new instance of the WebApplicationBuilder class.


// Add services to the container.


// builder.Services.AddSingleton<IDispatcherClientConnect, RequestDispatcherService>();

// builder.Services.AddSingleton<IElevatorControlService, ElevatorControlService>();

var lDispatcherService = new RequestDispatcherService();
builder.Services.AddHostedService(sp => lDispatcherService);
builder.Services.AddSingleton<IRequestDispatcherService>(lDispatcherService);


var lRequestProcessor = new ElevatorControlService(lDispatcherService);
builder.Services.AddHostedService(sp => lRequestProcessor);
builder.Services.AddSingleton<IElevatorControlService>(lRequestProcessor);

// builder.Services.AddHostedService<ElevatorControlService>();

builder.Services.AddControllers();
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
