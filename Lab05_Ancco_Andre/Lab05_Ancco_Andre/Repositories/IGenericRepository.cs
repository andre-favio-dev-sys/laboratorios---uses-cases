using Lab05_Ancco_Andre.Models;

namespace Lab05_Ancco_Andre.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity?> GetByIdAsync(int id);

    Task<TEntity> InsertAsync(TEntity entity);

    Task<TEntity> InsertAndSaveAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);
    Task AddAsync(User usuario);
}