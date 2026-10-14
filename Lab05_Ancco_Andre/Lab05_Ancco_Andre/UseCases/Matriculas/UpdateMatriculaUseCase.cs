using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Matriculas;

public class UpdateMatriculaUseCase(IUnitOfWork unitOfWork)
{
    public async Task<bool> ExecuteAsync(int id, Matricula matricula)
    {
        var repository = unitOfWork.Repository<Matricula>();
        var actual = await repository.GetByIdAsync(id);

        if (actual == null)
            return false;

        actual.IdEstudiante = matricula.IdEstudiante;
        actual.IdCurso = matricula.IdCurso;
        actual.Semestre = matricula.Semestre;

        repository.Update(actual);
        await unitOfWork.Complete();
        return true;
    }
}
