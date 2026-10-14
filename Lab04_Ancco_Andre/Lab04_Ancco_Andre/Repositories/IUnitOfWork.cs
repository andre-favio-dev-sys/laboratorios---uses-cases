using Lab04_Ancco_Andre.Models;

namespace Lab04_Ancco_Andre.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Cliente> Clientes { get; }
    IGenericRepository<Producto> Productos { get; }
    IGenericRepository<Categoria> Categorias { get; }
    IGenericRepository<Ordene> Ordenes { get; }
    IGenericRepository<Detallesorden> DetallesOrden { get; }
    IGenericRepository<Pago> Pagos { get; }

    int SaveChanges();
}