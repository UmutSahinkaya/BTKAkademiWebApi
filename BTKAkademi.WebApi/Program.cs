using BTKAkademi.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;
using NLog;
using Repositories.EFCore;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
})
    .AddCustomCsvFormatter()
    .AddXmlDataContractSerializerFormatters()//xml formatýndada çýkýþ verebilecek
    .AddApplicationPart(typeof(Presentation.AssemblyRefence).Assembly)
    .AddNewtonsoftJson(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

var logger=app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsProduction())
{
    app.UseHsts(); //.NetSecurity
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
