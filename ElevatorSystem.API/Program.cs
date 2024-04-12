using ElevatorSystem.Application;
using ElevatorSystem.Infrastructure;

var builder = WebApplication.CreateBuilder(args); // Create a new instance of the WebApplicationBuilder class.


// Add services to the container.


builder.Services.AddSingleton<Elevator>();
builder.Services.AddSingleton<IElevatorService, ElevatorService>();

builder.Services.AddHostedService<ElevatorRequestProcessor>();

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
