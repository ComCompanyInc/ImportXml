using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories;
using BackendApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddControllers()
    .AddXmlSerializerFormatters();

// регестируем все сервисные классы приложения для DI
builder.Services.AddScoped<F031_ErmosService>();
builder.Services.AddScoped<BaseDataService>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<DocumentService>();
builder.Services.AddScoped<MoDocumentService>();
builder.Services.AddScoped<OrganizationService>();
builder.Services.AddScoped<CommunicationService>();

// регестируем все репозиторные классы приложения для DI
builder.Services.AddScoped<F031_ErmosRepository>();
builder.Services.AddScoped<BaseDataRepository>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<DocumentRepository>();
builder.Services.AddScoped<MoDocumentRepository>();
builder.Services.AddScoped<OrganizationRepository>();
builder.Services.AddScoped<CommunicationRepository>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
