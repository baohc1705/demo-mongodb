using DemoMongoDb.Application;
using DemoMongoDb.Grpc.Services;
using DemoMongoDb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);



// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddGrpcReflection();

var app = builder.Build();

IWebHostEnvironment env = app.Environment;
if (env.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

// Configure the HTTP request pipeline.
app.MapGrpcService<MenuGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
