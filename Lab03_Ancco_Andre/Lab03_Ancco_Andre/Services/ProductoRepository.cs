using Lab03_Ancco_Andre.Models;
using Lab03_Ancco_Andre.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab03_Ancco_Andre.Services;

public class ProductoRepository : Repository<Producto>, IProductoRepository
{
    private readonly TiendaDbContext _context;

    public ProductoRepository(TiendaDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Producto?> GetByNombre(string nombre)
    {
        return await _context.Productos
            .FirstOrDefaultAsync(p => p.Nombre == nombre);
    }

    public async Task<bool> IsAvailableProducto(string nombre)
    {
        return await _context.Productos
            .AnyAsync(p => p.Nombre == nombre);
    }

    public async Task<IEnumerable<Producto>> GetByCategoria(int categoriaId)
    {
        return await _context.Productos
            .Where(p => p.CategoriaId == categoriaId)
            .ToListAsync();
    }
}