using Lab_06_Andre_Ancco.Models;

namespace Lab_06_Andre_Ancco.Repositories.Implements;

public interface IUserRepository : IGenericRepository<User1>
{
    Task<User1?> GetByUsernameAsync(string username);
}