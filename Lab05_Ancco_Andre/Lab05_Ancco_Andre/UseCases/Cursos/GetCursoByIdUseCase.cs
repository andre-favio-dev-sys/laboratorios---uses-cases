using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Cursos;

public class GetCursoByIdUseCase(IUnitOfWork unitOfWork)
{
    public Task<Curso?> ExecuteAsync(int id)
    {
        return unitOfWork.Repository<Curso>().GetByIdAsync(id);
    }
}
