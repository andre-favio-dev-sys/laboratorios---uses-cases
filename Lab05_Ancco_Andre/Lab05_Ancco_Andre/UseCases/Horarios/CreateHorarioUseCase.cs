using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Horarios;

public class CreateHorarioUseCase(IUnitOfWork unitOfWork)
{
    public async Task<Horario> ExecuteAsync(Horario horario)
    {
        await unitOfWork.Repository<Horario>().InsertAsync(horario);
        await unitOfWork.Complete();
        return horario;
    }
}
