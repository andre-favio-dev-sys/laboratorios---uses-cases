using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Cursos;

public class UpdateCursoUseCase(IUnitOfWork unitOfWork)
{
    public async Task<bool> ExecuteAsync(int id, Curso curso)
    {
        var repository = unitOfWork.Repository<Curso>();
        var actual = await repository.GetByIdAsync(id);

        if (actual == null)
            return false;

        actual.Nombre = curso.Nombre;
        actual.Descripcion = curso.Descripcion;
        actual.Creditos = curso.Creditos;
        actual.IdProfesor = curso.IdProfesor;

        repository.Update(actual);
        await unitOfWork.Complete();
        return true;
    }
}
