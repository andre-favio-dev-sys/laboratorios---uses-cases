using Lab04_Ancco_Andre.Models;

namespace Lab04_Ancco_Andre.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly TiendaDbContext _context;

    public IGenericRepository<Cliente> Clientes { get; }
    public IGenericRepository<Producto> Productos { get; }
    public IGenericRepository<Categoria> Categorias { get; }
    public IGenericRepository<Ordene> Ordenes { get; }
    public IGenericRepository<Detallesorden> DetallesOrden { get; }
    public IGenericRepository<Pago> Pagos { get; }

    public UnitOfWork(
        TiendaDbContext context,
        IGenericRepository<Cliente> clientes,
        IGenericRepository<Producto> productos,
        IGenericRepository<Categoria> categorias,
        IGenericRepository<Ordene> ordenes,
        IGenericRepository<Detallesorden> detallesOrden,
        IGenericRepository<Pago> pagos)
    {
        _context = context;

        Clientes = clientes;
        Productos = productos;
        Categorias = categorias;
        Ordenes = ordenes;
        DetallesOrden = detallesOrden;
        Pagos = pagos;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}  