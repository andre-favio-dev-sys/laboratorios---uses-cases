using System.Text;
using Lab05_Ancco_Andre.Data;
using Lab05_Ancco_Andre.Repositories;
using Lab05_Ancco_Andre.Repositories.Implements;
using Lab05_Ancco_Andre.Services;
using Lab05_Ancco_Andre.Services.Implements;
using Lab05_Ancco_Andre.UseCases.Cursos;
using Lab05_Ancco_Andre.UseCases.Estudiantes;
using Lab05_Ancco_Andre.UseCases.Horarios;
using Lab05_Ancco_Andre.UseCases.Matriculas;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Description = "Ingresa solo el token JWT."
    });

    c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});

builder.Services.AddDbContext<UniversidadDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


// Casos de uso de cursos
builder.Services.AddScoped<GetAllCursosUseCase>();
builder.Services.AddScoped<GetCursoByIdUseCase>();
builder.Services.AddScoped<CreateCursoUseCase>();
builder.Services.AddScoped<UpdateCursoUseCase>();
builder.Services.AddScoped<DeleteCursoUseCase>();

// Casos de uso de estudiantes
builder.Services.AddScoped<GetAllEstudiantesUseCase>();
builder.Services.AddScoped<GetEstudianteByIdUseCase>();
builder.Services.AddScoped<CreateEstudianteUseCase>();
builder.Services.AddScoped<UpdateEstudianteUseCase>();
builder.Services.AddScoped<DeleteEstudianteUseCase>();

// Casos de uso de horarios
builder.Services.AddScoped<GetAllHorariosUseCase>();
builder.Services.AddScoped<GetHorarioByIdUseCase>();
builder.Services.AddScoped<CreateHorarioUseCase>();
builder.Services.AddScoped<UpdateHorarioUseCase>();
builder.Services.AddScoped<DeleteHorarioUseCase>();

// Casos de uso de matrículas
builder.Services.AddScoped<GetAllMatriculasUseCase>();
builder.Services.AddScoped<GetMatriculaByIdUseCase>();
builder.Services.AddScoped<CreateMatriculaUseCase>();
builder.Services.AddScoped<UpdateMatriculaUseCase>();
builder.Services.AddScoped<DeleteMatriculaUseCase>();
builder.Services.AddScoped<GetDetalleCursoUseCase>();


builder.Services.AddScoped<IAuthService, AuthService>();

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

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                    builder.Configuration["Jwt:SecretKey"]!
                )
            )
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(
        "Administrador",
        policy => policy.RequireRole("Admin")
    );

    options.AddPolicy(
        "Usuario",
        policy => policy.RequireRole("Admin", "Usuario")
    );
});

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception =
            context.Features.Get<IExceptionHandlerFeature>()?.Error;

        context.Response.StatusCode = exception switch
        {
            UnauthorizedAccessException =>
                StatusCodes.Status401Unauthorized,

            InvalidOperationException =>
                StatusCodes.Status400BadRequest,

            _ =>
                StatusCodes.Status500InternalServerError
        };

        context.Response.ContentType = "application/json";

        await context.Response.WriteAsJsonAsync(new
        {
            message = exception?.Message
        });
    });
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint(
            "/swagger/v1/swagger.json",
            "Lab05 Ancco Andre API v1"
        );

        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
