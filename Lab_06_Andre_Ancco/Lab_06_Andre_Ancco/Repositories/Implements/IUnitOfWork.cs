namespace Lab_06_Andre_Ancco.Repositories.Implements;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    IGenericRepository<TEntity> Repository<TEntity>()
        where TEntity : class;

    Task<int> Complete();
}