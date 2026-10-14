using Lab07_Ancco_Andre.Middleware;
using Lab07_Ancco_Andre.UseCases.Products;

var builder = WebApplication.CreateBuilder(args);

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<CreateProductUseCase>();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Middlewares
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<ParameterValidationMiddleware>();
//app.UseMiddleware<RoleBasedAccessMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
