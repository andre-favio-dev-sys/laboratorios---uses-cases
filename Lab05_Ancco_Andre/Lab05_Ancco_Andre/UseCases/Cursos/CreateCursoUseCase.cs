using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Cursos;

public class CreateCursoUseCase(IUnitOfWork unitOfWork)
{
    public async Task<Curso> ExecuteAsync(Curso curso)
    {
        await unitOfWork.Repository<Curso>().InsertAsync(curso);
        await unitOfWork.Complete();
        return curso;
    }
}
