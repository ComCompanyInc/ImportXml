using BackendApp.Data;
using BackendApp.Models;
using BackendApp.Repositories;
using BackendApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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
builder.Services.AddScoped<OrgDocumentService>();
builder.Services.AddScoped<OrganizationService>();
builder.Services.AddScoped<CommunicationService>();
builder.Services.AddScoped<OspTypeService>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<VidTypeService>();
builder.Services.AddScoped<F032_TrmosService>();
builder.Services.AddScoped<DistrictService>();
builder.Services.AddScoped<OidTypeService>();
builder.Services.AddScoped<F033_SpmosService>();
builder.Services.AddScoped<F038_AddrmpsService>();

// регестируем все репозиторные классы приложения для DI
builder.Services.AddScoped<F031_ErmosRepository>();
builder.Services.AddScoped<BaseDataRepository>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<DocumentRepository>();
builder.Services.AddScoped<OrgDocumentRepository>();
builder.Services.AddScoped<OrganizationRepository>();
builder.Services.AddScoped<CommunicationRepository>();
builder.Services.AddScoped<OspTypeRepository>();
builder.Services.AddScoped<SubjectRepository>();
builder.Services.AddScoped<VidTypeRepository>();
builder.Services.AddScoped<F032_TrmoRepository>();
builder.Services.AddScoped<DistrictRepository>();
builder.Services.AddScoped<OidTypeRepository>();
builder.Services.AddScoped<F033_SpmoRepository>();
builder.Services.AddScoped<F038_AddrmpRepository>();

// Задаем лимит тела запросов на сервер до 100 Мб
builder.WebHost.ConfigureKestrel(options =>
{
    options.Limits.MaxRequestBodySize = 100_000_000;
});

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
