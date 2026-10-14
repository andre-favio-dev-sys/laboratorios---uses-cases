using System.Collections;
using Lab_06_Andre_Ancco.Models;
using Lab_06_Andre_Ancco.Repositories.Implements;

namespace Lab_06_Andre_Ancco.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly UniversidadDbContext _context;
    private readonly Hashtable _repositories;

    public IUserRepository Users { get; }

    public UnitOfWork(UniversidadDbContext context)
    {
        _context = context;
        _repositories = new Hashtable();

        Users = new UserRepository(context);
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

    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }
}