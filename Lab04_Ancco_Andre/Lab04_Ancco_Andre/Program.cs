using Lab04_Ancco_Andre.Models;
using Lab04_Ancco_Andre.Repositories;
using Lab04_Ancco_Andre.UseCases.Categorias;
using Lab04_Ancco_Andre.UseCases.Clientes;
using Lab04_Ancco_Andre.UseCases.DetallesOrden;
using Lab04_Ancco_Andre.UseCases.Ordenes;
using Lab04_Ancco_Andre.UseCases.Pagos;
using Lab04_Ancco_Andre.UseCases.Productos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TiendaDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Casos de uso
builder.Services.AddScoped<GetAllClientesUseCase>();
builder.Services.AddScoped<GetClienteByIdUseCase>();
builder.Services.AddScoped<CreateClienteUseCase>();
builder.Services.AddScoped<UpdateClienteUseCase>();
builder.Services.AddScoped<DeleteClienteUseCase>();

builder.Services.AddScoped<GetAllCategoriasUseCase>();
builder.Services.AddScoped<GetCategoriaByIdUseCase>();
builder.Services.AddScoped<CreateCategoriaUseCase>();
builder.Services.AddScoped<UpdateCategoriaUseCase>();
builder.Services.AddScoped<DeleteCategoriaUseCase>();

builder.Services.AddScoped<GetAllProductosUseCase>();
builder.Services.AddScoped<GetProductoByIdUseCase>();
builder.Services.AddScoped<CreateProductoUseCase>();
builder.Services.AddScoped<UpdateProductoUseCase>();
builder.Services.AddScoped<DeleteProductoUseCase>();

builder.Services.AddScoped<GetAllOrdenesUseCase>();
builder.Services.AddScoped<GetOrdenByIdUseCase>();
builder.Services.AddScoped<CreateOrdenUseCase>();
builder.Services.AddScoped<UpdateOrdenUseCase>();
builder.Services.AddScoped<DeleteOrdenUseCase>();

builder.Services.AddScoped<GetAllDetallesOrdenUseCase>();
builder.Services.AddScoped<GetDetalleOrdenByIdUseCase>();
builder.Services.AddScoped<CreateDetalleOrdenUseCase>();
builder.Services.AddScoped<UpdateDetalleOrdenUseCase>();
builder.Services.AddScoped<DeleteDetalleOrdenUseCase>();

builder.Services.AddScoped<GetAllPagosUseCase>();
builder.Services.AddScoped<GetPagoByIdUseCase>();
builder.Services.AddScoped<CreatePagoUseCase>();
builder.Services.AddScoped<UpdatePagoUseCase>();
builder.Services.AddScoped<DeletePagoUseCase>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();
