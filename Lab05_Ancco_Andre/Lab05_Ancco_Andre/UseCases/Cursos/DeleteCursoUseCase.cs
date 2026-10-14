using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Cursos;

public class DeleteCursoUseCase(IUnitOfWork unitOfWork)
{
    public async Task<bool> ExecuteAsync(int id)
    {
        var repository = unitOfWork.Repository<Curso>();
        var curso = await repository.GetByIdAsync(id);

        if (curso == null)
            return false;

        repository.Delete(curso);
        await unitOfWork.Complete();
        return true;
    }
}
