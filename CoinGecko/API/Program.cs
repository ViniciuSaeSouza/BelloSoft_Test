using Application.Services;
using Domain.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;


DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);
string connectionString = Environment.GetEnvironmentVariable("ConnectionString__SQLServer");

// Add services to the container.
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CoinGecko API",
        Version = "v1",
        Description = "An API for retrieving and storing cryptocurrency data from CoinGecko",
        Contact = new OpenApiContact
        {
            Name = "Vinícius Saes",
            Email = "viniciusaesouza@gmail.com"
        }
    });
    
    
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure")
    )
);

// Register services
builder.Services.AddScoped<ICoinGeckoService, CoinGeckoService>();
builder.Services.AddScoped<ICryptoService, CryptoService>();
builder.Services.AddHttpClient<ICoinGeckoService, CoinGeckoService>();


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
