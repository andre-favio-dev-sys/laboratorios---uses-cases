using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Cursos;

public class GetAllCursosUseCase(IUnitOfWork unitOfWork)
{
    public Task<IEnumerable<Curso>> ExecuteAsync()
    {
        return unitOfWork.Repository<Curso>().GetAllAsync();
    }
}
