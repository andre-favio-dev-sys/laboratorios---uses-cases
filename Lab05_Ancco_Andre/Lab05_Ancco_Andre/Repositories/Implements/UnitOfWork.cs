using System.Collections;
using Lab05_Ancco_Andre.Data;

namespace Lab05_Ancco_Andre.Repositories.Implements;

public class UnitOfWork : IUnitOfWork
{
    private readonly Hashtable _repositories;
    //llanar al genercio desde le unit of work, digamos agregar ahora de asistenciaRepositorypero solo aqui ya no en de generic 
    private readonly UniversidadDbContext _context;

    public UnitOfWork(UniversidadDbContext context)
    {
        _context = context;
        _repositories = new Hashtable();
    }
 
    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }

    public IGenericRepository<TEntity> Repository<TEntity>()
        where TEntity : class
    {
        var type = typeof(TEntity).Name;

        if (_repositories.ContainsKey(type))
        {
            return (IGenericRepository<TEntity>)_repositories[type]!;
        }

        var repositoryType = typeof(GenericRepository<>);

        var repositoryInstance = Activator.CreateInstance(
            repositoryType.MakeGenericType(typeof(TEntity)),
            _context
        );

        if (repositoryInstance != null)
        {
            _repositories.Add(type, repositoryInstance);

            return (IGenericRepository<TEntity>)repositoryInstance;
        }

        throw new Exception(
            $"Could not create repository instance for type {type}"
        );
    }
}