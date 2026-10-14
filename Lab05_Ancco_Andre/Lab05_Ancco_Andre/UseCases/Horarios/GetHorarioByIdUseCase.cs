using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Horarios;

public class GetHorarioByIdUseCase(IUnitOfWork unitOfWork)
{
    public Task<Horario?> ExecuteAsync(int id)
    {
        return unitOfWork.Repository<Horario>().GetByIdAsync(id);
    }
}
