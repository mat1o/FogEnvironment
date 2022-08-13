using FogEnvironment.NodeManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.SeviceRegistration();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


