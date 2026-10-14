using Microsoft.EntityFrameworkCore;

using Lab_06_Andre_Ancco.Models;
using Lab_06_Andre_Ancco.Repositories.Implements;

namespace Lab_06_Andre_Ancco.Repositories;

public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : class
{
    protected readonly UniversidadDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public GenericRepository(UniversidadDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }
}