using Lab04_Ancco_Andre.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab04_Ancco_Andre.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly TiendaDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(TiendaDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}