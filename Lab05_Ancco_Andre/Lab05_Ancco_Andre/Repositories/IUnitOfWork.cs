namespace Lab05_Ancco_Andre.Repositories;

public interface IUnitOfWork
{
    IGenericRepository<TEntity> Repository<TEntity>()
        where TEntity : class;

    Task<int> Complete();
}