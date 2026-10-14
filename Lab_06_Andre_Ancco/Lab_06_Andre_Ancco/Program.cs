using System.Text;

using Lab_06_Andre_Ancco.Models;
using Lab_06_Andre_Ancco.Repositories;
using Lab_06_Andre_Ancco.Repositories.Implements;
using Lab_06_Andre_Ancco.Services;
using Lab_06_Andre_Ancco.Services.Implementes;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// =========================
// CONFIGURACIÓN JWT
// =========================

var jwtKey = builder.Configuration["Jwt:SecretKey"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("No se encontró Jwt:SecretKey en appsettings.json");
}

// =========================
// CONTROLLERS
// =========================

builder.Services.AddControllers();

// =========================
// BASE DE DATOS
// =========================

builder.Services.AddDbContext<UniversidadDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// =========================
// UNIT OF WORK
// =========================

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// =========================
// SERVICIOS
// =========================

builder.Services.AddScoped<IAuthService, AuthService>();

// =========================
// AUTENTICACIÓN JWT
// =========================

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            )
        };
    });

// =========================
// AUTORIZACIÓN
// =========================

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "Administrador",
        policy => policy.RequireRole("Admin")
    );

    options.AddPolicy(
        "PuedeVerUsuarios",
        policy => policy.RequireClaim("CanViewUsers", "true")
    );

    options.AddPolicy(
        "PuedeEditarUsuarios",
        policy => policy.RequireClaim("CanEditUsers", "true")
    );
});

// =========================
// SWAGGER
// =========================

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "Lab 06 API",
            Version = "v1"
        }
    );

    options.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "Ingrese el token JWT"
        }
    );
});

// =========================
// CREAR APP
// =========================

var app = builder.Build();

// =========================
// SWAGGER
// =========================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// =========================
// MIDDLEWARE
// =========================

// Puedes dejar esto comentado si solo estás usando HTTP
// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();