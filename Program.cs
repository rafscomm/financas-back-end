using System.Globalization;
using System.Text;
using System.Text.Json.Serialization;
using financas.Repository;
using financas.Repository.Interfaces;
using financas.Services;
using financas.Services.Interfaces;
using financas.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();

var mysqlString = builder.Configuration["ConnectionString:DefaultConnection"];

builder.Services.AddDbContext<FnDbContext>(options => options.UseMySql(mysqlString, new MySqlServerVersion(new Version("5.6"))));

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDespesasService, DespesasService>();
builder.Services.AddScoped<IDespesasRepository, DespesasRepository>();

builder.Services.AddScoped<IPessoasService, PessoasService>();
builder.Services.AddScoped<IPessoasRepository, PessoasRepository>();

builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IUsuariosService, UsuariosService>();

builder.Services.AddScoped<ITokenService, TokenService>();

var secretKey = builder.Configuration["JWT:Key"] ?? throw new ArgumentException("Ivalid secret Key");

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssue"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
    };
});

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

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
