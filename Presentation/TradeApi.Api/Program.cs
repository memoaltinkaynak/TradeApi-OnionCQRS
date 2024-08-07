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


//bu kod parçasý uygulamanýn temel yapýlandýrma dosyasýný (appsettings.json) ve ortam bazlý
//yapýlandýrma dosyasýný (örneðin appsettings.Development.json, appsettings.Production.json) yükler.
//Bu sayede uygulama, farklý ortamlarda (geliþtirme, test, üretim) farklý yapýlandýrmalar kullanabilir.
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
