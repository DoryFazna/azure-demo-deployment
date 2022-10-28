using Ocelot.DependencyInjection;
using Ocelot.Middleware;
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("Ocelot.json");

builder.Services.AddOcelot();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy =>
        {
            policy
            .AllowAnyHeader().AllowAnyOrigin()
            .AllowAnyMethod();
        });
});

var app = builder.Build();


app.UseCors(myAllowSpecificOrigins);

app.UseOcelot().Wait();

app.MapGet("/", () => "Hello World!");

app.Run();
