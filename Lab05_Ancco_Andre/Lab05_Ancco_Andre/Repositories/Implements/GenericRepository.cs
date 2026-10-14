using Lab05_Ancco_Andre.Data;
using Lab05_Ancco_Andre.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab05_Ancco_Andre.Repositories.Implements;

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

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task<TEntity> InsertAndSaveAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public Task AddAsync(User usuario)
    {
        throw new NotImplementedException();
    }
}