using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Horarios;

public class DeleteHorarioUseCase(IUnitOfWork unitOfWork)
{
    public async Task<bool> ExecuteAsync(int id)
    {
        var repository = unitOfWork.Repository<Horario>();
        var horario = await repository.GetByIdAsync(id);

        if (horario == null)
            return false;

        repository.Delete(horario);
        await unitOfWork.Complete();
        return true;
    }
}
