using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Renter.Interview.Domain.Interfaces;
using Renter.Interview.Domain.Services;
using Rentler.Interview.Api.Configuration;
using Rentler.Interview.Repos;
using Rentler.Interview.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

Log.Logger = new LoggerConfiguration().ReadFrom
    .Configuration(builder.Configuration)
    .CreateLogger();

builder.WebHost.UseSerilog();

// Add services to the container.
var appSettingsSection = builder.Configuration.GetSection("AppSettings");
var connectionStringsSection = builder.Configuration.GetSection("ConnectionStrings");

builder.Services.Configure<AppSettings>(appSettingsSection);
builder.Services.Configure<ConnectionStrings>(connectionStringsSection);
builder.Services.AddTransient<IFoodRepository, FoodRepository>();
builder.Services.AddTransient<IFoodService, FoodService>();

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
