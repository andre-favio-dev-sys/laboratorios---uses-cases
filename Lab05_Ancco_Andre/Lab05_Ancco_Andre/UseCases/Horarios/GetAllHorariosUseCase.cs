using Lab05_Ancco_Andre.Models;
using Lab05_Ancco_Andre.Repositories;

namespace Lab05_Ancco_Andre.UseCases.Horarios;

public class GetAllHorariosUseCase(IUnitOfWork unitOfWork)
{
    public Task<IEnumerable<Horario>> ExecuteAsync()
    {
        return unitOfWork.Repository<Horario>().GetAllAsync();
    }
}
