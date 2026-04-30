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
builder.Services.AddScoped<OrgNameService>();
builder.Services.AddScoped<LicenseService>();
builder.Services.AddScoped<F037_LicmoService>();
builder.Services.AddScoped<F002_InsIncludeService>();
builder.Services.AddScoped<F002_SmoEmpService>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<OrgTypeService>();
builder.Services.AddScoped<F002_Smo_InsAdviceService>();
builder.Services.AddScoped<PaymentStatusService>();
builder.Services.AddScoped<F005_StatOplService>();
builder.Services.AddScoped<ExpTypeService>();
builder.Services.AddScoped<F006_VidExpService>();
builder.Services.AddScoped<VedomTypeService>();
builder.Services.AddScoped<F007_VedomService>();
builder.Services.AddScoped<OmsTypeService>();
builder.Services.AddScoped<F008_TipOmsService>();
builder.Services.AddScoped<StatTypeService>();
builder.Services.AddScoped<F009_StatZlService>();
builder.Services.AddScoped<F010_SubectiService>();
builder.Services.AddScoped<F011_TipdocService>();
builder.Services.AddScoped<F012_TipSchService>();
builder.Services.AddScoped<F015_OkrugService>();
builder.Services.AddScoped<F017_BillTypesService>();

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
builder.Services.AddScoped<OrgNameRepository>();
builder.Services.AddScoped<LicenseRepository>();
builder.Services.AddScoped<F037_LicmoRepository>();
builder.Services.AddScoped<F002_InsIncludeRepository>();
builder.Services.AddScoped<F002_SmoEmpRepository>();
builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<OrgTypeRepository>();
builder.Services.AddScoped<F002_Smo_InsAdviceRepository>();
builder.Services.AddScoped<PaymentStatusRepository>();
builder.Services.AddScoped<F005_StatOplRepository>();
builder.Services.AddScoped<ExpTypeRepository>();
builder.Services.AddScoped<F006_VidExpRepository>();
builder.Services.AddScoped<VedomTypeRepository>();
builder.Services.AddScoped<F007_VedomRepository>();
builder.Services.AddScoped<OmsTypeRepository>();
builder.Services.AddScoped<F008_TipOmsRepository>();
builder.Services.AddScoped<StatTypeRepository>();
builder.Services.AddScoped<F009_StatZlRepository>();
builder.Services.AddScoped<f010_SubectiRepository>();
builder.Services.AddScoped<F011_TopicRepository>();
builder.Services.AddScoped<F012_TipSchRepository>();
builder.Services.AddScoped<F015_OkrugRepository>();
builder.Services.AddScoped<F017_BillTypesRepository>();

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
