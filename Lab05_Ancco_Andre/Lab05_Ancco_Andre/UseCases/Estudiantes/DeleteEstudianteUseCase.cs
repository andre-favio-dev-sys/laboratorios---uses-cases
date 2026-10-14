using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Estudiantes;

public class DeleteEstudianteUseCase(IUnitOfWork unitOfWork)
{
    public async Task<bool> ExecuteAsync(int id)
    {
        var repository = unitOfWork.Repository<Estudiante>();
        var estudiante = await repository.GetByIdAsync(id);

        if (estudiante == null)
            return false;

        repository.Delete(estudiante);
        await unitOfWork.Complete();
        return true;
    }
}
