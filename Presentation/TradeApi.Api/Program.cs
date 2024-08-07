using TradeApi.Persistence;
using TradeApi.Application;
using TradeApi.Infrastructure;
using TradeApi.Mapper;
using TradeApi.Application.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//bu kod par�as� uygulaman�n temel yap�land�rma dosyas�n� (appsettings.json) ve ortam bazl�
//yap�land�rma dosyas�n� (�rne�in appsettings.Development.json, appsettings.Production.json) y�kler.
//Bu sayede uygulama, farkl� ortamlarda (geli�tirme, test, �retim) farkl� yap�land�rmalar kullanabilir.
var env = builder.Environment;
builder.Configuration
    .SetBasePath(env.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddCustomMapper();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();
