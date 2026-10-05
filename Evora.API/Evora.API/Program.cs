using Evora.API;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

// Register all services from Startup
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Configure middleware from Startup
startup.Configure(app, app.Environment);

app.Run();
