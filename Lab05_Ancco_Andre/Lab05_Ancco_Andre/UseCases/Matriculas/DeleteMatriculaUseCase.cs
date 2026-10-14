using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Matriculas;

public class DeleteMatriculaUseCase(IUnitOfWork unitOfWork)
{
    public async Task<bool> ExecuteAsync(int id)
    {
        var repository = unitOfWork.Repository<Matricula>();
        var matricula = await repository.GetByIdAsync(id);

        if (matricula == null)
            return false;

        repository.Delete(matricula);
        await unitOfWork.Complete();
        return true;
    }
}
