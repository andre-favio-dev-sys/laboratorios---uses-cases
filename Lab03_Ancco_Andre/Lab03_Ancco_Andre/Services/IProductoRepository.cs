using Lab03_Ancco_Andre.Models;
using Lab03_Ancco_Andre.Repositories;

namespace Lab03_Ancco_Andre.Services;

public interface IProductoRepository : IRepository<Producto>
{
    Task<Producto?> GetByNombre(string nombre);
    Task<bool> IsAvailableProducto(string nombre);
    Task<IEnumerable<Producto>> GetByCategoria(int categoriaId);
}