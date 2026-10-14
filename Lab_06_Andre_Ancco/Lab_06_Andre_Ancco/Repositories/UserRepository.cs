using Microsoft.EntityFrameworkCore;

using Lab_06_Andre_Ancco.Models;
using Lab_06_Andre_Ancco.Repositories.Implements;

namespace Lab_06_Andre_Ancco.Repositories;

public class UserRepository : GenericRepository<User1>, IUserRepository
{
    public UserRepository(UniversidadDbContext context)
        : base(context)
    {
    }

    public async Task<User1?> GetByUsernameAsync(string username)
    {
        return await _context.Users1
            .FirstOrDefaultAsync(u => u.UserName == username);
    }
}