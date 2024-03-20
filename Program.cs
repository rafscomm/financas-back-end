using System.Globalization;
using System.Text.Json.Serialization;
using financas.Services;
using financas.Services.Interfaces;
using financas.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

var mysqlString = builder.Configuration["ConnectionString:DefaultConnection"];

builder.Services.AddDbContext<FnDbContext>(options => options.UseMySql(mysqlString, new MySqlServerVersion(new Version("5.6"))));

builder.Services.AddScoped<IDespesasService, DespesasService>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

var supportedCultures = new[]
{
    new CultureInfo("pt-BR")
};

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
